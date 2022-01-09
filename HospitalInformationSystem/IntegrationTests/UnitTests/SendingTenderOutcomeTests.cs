using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Controllers;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Service;
using IntegrationClassLib.Tendering.Service.Interface;
using IntegrationTests.InMemoryRepository;
using Moq;
using Shouldly;
using Xunit;

namespace IntegrationTests.UnitTests
{
    public class SendingTenderOutcomeTests
    {
        private readonly long WINNER_OFFER_ID = 1;
        private readonly string WINNER_PHARMACY_NAME = "Apoteka1";
        private readonly long TENDER_ID = 1;
        private TenderingController tenderingController;
        private Mock<IPharmacyHTTPConnection> stubPharmacyHttpConnection;
        private List<PharmacyOffer> pharmacyOffers;

        [Fact]
        public void Successful_sending_tender_offer()
        {
            PrepareServicesForSuccessfulSendingTenderOutcome();

            PharmacyOffer pharmacyOffer = tenderingController.TryOfferClosing(WINNER_OFFER_ID);

            stubPharmacyHttpConnection.Verify(x => x.SendTenderOutcomeToWinnerPharmacy(It.IsAny<PharmacyOffer>()), Times.Once);
            stubPharmacyHttpConnection.Verify(x => x.SendTenderOutcomeToAllLoserPharmacies(pharmacyOffers, WINNER_OFFER_ID), Times.Once);
            pharmacyOffer.Id.ShouldBe(WINNER_OFFER_ID);
            pharmacyOffer.PharmacyName.ShouldBe(WINNER_PHARMACY_NAME);
        }

        private void PrepareServicesForSuccessfulSendingTenderOutcome()
        {
            var stubPharmacyOfferService = new Mock<IPharmacyOfferService>();
            stubPharmacyOfferService.Setup(m => m.GetPharmacyOfferById(WINNER_OFFER_ID)).Returns(new PharmacyOffer() {Id = WINNER_OFFER_ID, TenderId = TENDER_ID, PharmacyName = WINNER_PHARMACY_NAME });
            pharmacyOffers = GetPharmacyOffers();
            stubPharmacyOfferService.Setup(m => m.GetAllPharmacyOffersByTenderId(TENDER_ID)).Returns(pharmacyOffers);

            var stubHospitalHttpConnection = new Mock<IHospitalHttpConnection>();
            stubPharmacyHttpConnection = new Mock<IPharmacyHTTPConnection>();
            stubPharmacyHttpConnection.Setup(m => m.SendTenderOutcomeToWinnerPharmacy(It.IsAny<PharmacyOffer>())).Returns(true);

            tenderingController = new TenderingController(new TenderService(new TenderingTestRepository(), new TenderCommunicationRabbitMQService()),
                    stubPharmacyOfferService.Object, stubHospitalHttpConnection.Object, stubPharmacyHttpConnection.Object);
        }

        [Fact]
        public void No_sending_to_loser_pharmacies_if_winner_dont_have_medicines()
        {
            PrepareServicesForUnsuccessfulSendingTenderOutcome();

            Action act = () => tenderingController.TryOfferClosing(WINNER_OFFER_ID);

            act.ShouldThrow<Exception>("Accepting offer gone wrong");
            stubPharmacyHttpConnection.Verify(x => x.SendTenderOutcomeToWinnerPharmacy(It.IsAny<PharmacyOffer>()), Times.Once);
            stubPharmacyHttpConnection.Verify(x => x.SendTenderOutcomeToAllLoserPharmacies(pharmacyOffers, WINNER_OFFER_ID), Times.Never);
        }

        private void PrepareServicesForUnsuccessfulSendingTenderOutcome()
        {
            var stubPharmacyOfferService = new Mock<IPharmacyOfferService>();
            stubPharmacyOfferService.Setup(m => m.GetPharmacyOfferById(WINNER_OFFER_ID)).Returns(new PharmacyOffer() { Id = WINNER_OFFER_ID, TenderId = TENDER_ID, PharmacyName = WINNER_PHARMACY_NAME });
            pharmacyOffers = GetPharmacyOffers();
            stubPharmacyOfferService.Setup(m => m.GetAllPharmacyOffersByTenderId(TENDER_ID)).Returns(pharmacyOffers);

            var stubHospitalHttpConnection = new Mock<IHospitalHttpConnection>();
            stubPharmacyHttpConnection = new Mock<IPharmacyHTTPConnection>();
            stubPharmacyHttpConnection.Setup(m => m.SendTenderOutcomeToWinnerPharmacy(It.IsAny<PharmacyOffer>())).Returns(false);

            tenderingController = new TenderingController(new TenderService(new TenderingTestRepository(), new TenderCommunicationRabbitMQService()),
                    stubPharmacyOfferService.Object, stubHospitalHttpConnection.Object, stubPharmacyHttpConnection.Object);
        }

        private List<PharmacyOffer> GetPharmacyOffers()
        {
            PharmacyOffer pharmacyOffer1 = new() { Id = WINNER_OFFER_ID, TenderId = TENDER_ID, PharmacyName = WINNER_PHARMACY_NAME };
            PharmacyOffer pharmacyOffer2 = new() { Id = 2, TenderId = TENDER_ID, PharmacyName = "Apoteka2" };
            PharmacyOffer pharmacyOffer3 = new() { Id = 3, TenderId = TENDER_ID, PharmacyName = "Apoteka3" };
            PharmacyOffer pharmacyOffer4 = new() { Id = 4, TenderId = TENDER_ID, PharmacyName = "Apoteka4" };

            return new List<PharmacyOffer> { pharmacyOffer1, pharmacyOffer2, pharmacyOffer3, pharmacyOffer4 };
        }
    }
}

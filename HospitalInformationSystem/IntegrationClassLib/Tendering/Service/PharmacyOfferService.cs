using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Repository;
using IntegrationClassLib.Tendering.Service.Interface;

namespace IntegrationClassLib.Tendering.Service
{
    public class PharmacyOfferService : IPharmacyOfferService
    {
        private readonly IPharmacyOfferRepository offerRepository;
        private readonly ITenderService tenderService;
        private readonly TenderCommunicationRabbitMQService tenderCommunicationRabbitMqService;

        public PharmacyOfferService(IPharmacyOfferRepository offerRepository, ITenderService tenderService,
            TenderCommunicationRabbitMQService tenderCommunicationRabbitMqService)
        {
            this.offerRepository = offerRepository;
            this.tenderService = tenderService;
            this.tenderCommunicationRabbitMqService = tenderCommunicationRabbitMqService;
        }

        public List<PharmacyOffer> GetAllPharmacyOffers()
        {
            CreateAllRecievedPharmacyOffer();
            return offerRepository.GetAllWithComponents();
        }

        public List<PharmacyOffer> GetAllPharmacyOffersByTenderId(long id)
        {
            return GetAllPharmacyOffers().Where(pharmacyOffer => pharmacyOffer.TenderId == id).ToList();
        }

        public PharmacyOffer AcceptOffer(long id)
        {
            PharmacyOffer pharmacyOffer = offerRepository.GetAllWithComponents().Find(offer => offer.Id == id);
            if (tenderService.AcceptOfferAndCloseTender(pharmacyOffer.TenderId) == null)
            {
                throw new Exception("Closing tender error");
            }

            // TODO: obavesti sve apoteke o zatvaranju

            // TODO: salji podatke apoteci koja je pobedila, ona treba da vrati da li ima te lekove
            // TODO: otkomentarisi if

            //if (imaLekove)
            //{
                return pharmacyOffer;
            //}

            throw new Exception("Accepting offer gone wrong");
        }

        private void CreateAllRecievedPharmacyOffer()
        {
            foreach (PharmacyOffer pharmacyOffer in tenderCommunicationRabbitMqService.GetReceivedTenderOffers())
            {
                offerRepository.Create(pharmacyOffer);
            }
        }
    }
}
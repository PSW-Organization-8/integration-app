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
        private readonly TenderCommunicationRabbitMQService tenderCommunicationRabbitMqService;

        public PharmacyOfferService(IPharmacyOfferRepository offerRepository, ITenderService tenderService,
            TenderCommunicationRabbitMQService tenderCommunicationRabbitMqService)
        {
            this.offerRepository = offerRepository;
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

        public PharmacyOffer GetPharmacyOfferById(long id)
        {
            return offerRepository.GetAllWithComponents().Find(offer => offer.Id == id);
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
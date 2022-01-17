using System;
using System.Collections.Generic;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Repository;
using IntegrationClassLib.Tendering.Service.Interface;

namespace IntegrationClassLib.Tendering.Service
{
    public class TenderService: ITenderService
    {
        private readonly ITenderingRepository tenderingRepository;
        private readonly TenderCommunicationRabbitMQService tenderCommunicationRabbitMqService;

        public TenderService(ITenderingRepository tenderingRepository, TenderCommunicationRabbitMQService tenderCommunicationRabbitMqService)
        {
            this.tenderingRepository = tenderingRepository;
            this.tenderCommunicationRabbitMqService = tenderCommunicationRabbitMqService;
        }

        public List<Tender> GetAll()
        {
            return this.tenderingRepository.GetAllWithMedications();
        }

        public Tender Create(Tender tender)
        {
            Tender createdTender = this.tenderingRepository.Create(tender);
            tenderCommunicationRabbitMqService.SendTenderToRegistratedPharmacies(createdTender);
            return createdTender;
        }

        public Tender CloseTender(long id)
        {
            Tender tender = tenderingRepository.Get(id);
            if (tender != null)
            {
                tender.DateRange.End = DateTime.Now;
                return tenderingRepository.Update(tender);
            }
            return null;
        }

        public Tender AcceptOfferAndCloseTender(long tenderId, long pharmacyOfferId)
        {
            Tender tender = tenderingRepository.Get(tenderId);
            if (tender != null)
            {
                tender.AcceptOffer(pharmacyOfferId);
                return tenderingRepository.Update(tender);
            }
            return null;
        }
    }
}

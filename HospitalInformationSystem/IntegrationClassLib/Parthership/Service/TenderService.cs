using IntegrationClassLib.Parthership.Model.Tendering;
using IntegrationClassLib.Parthership.Repository.TenderingRepository;
using IntegrationClassLib.Parthership.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Service
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
                tender.EndDate = DateTime.Now;
                return tenderingRepository.Update(tender);
            }
            return null;
        }
    }
}

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

        public TenderService(ITenderingRepository tenderingRepository)
        {
            this.tenderingRepository = tenderingRepository;
        }

        public List<Tender> GetAll()
        {
            return this.tenderingRepository.GetAllWithMedications();
        }

        public Tender Create(Tender tender)
        {
            return this.tenderingRepository.Create(tender);
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

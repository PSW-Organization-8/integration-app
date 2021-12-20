using IntegrationAPI.Dto;
using IntegrationClassLib.Parthership.Model.Tendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class TenderMapper
    {
        public static Tender TenderDtoToTender(TenderDto tenderDto)
        {
            try
            {
                int year = 0;
                int month = 0;
                int day = 0;
                DateTime? endDate = null;
                if (!tenderDto.complationDate.Equals(""))
                {
                    string[] dateString = tenderDto.complationDate.Split("-");
                    year = int.Parse(dateString[0]);
                    month = int.Parse(dateString[1]);
                    day = int.Parse(dateString[2]);
                    endDate = new DateTime(year, month, day, 23, 59, 59);
                }


                return new Tender()
                {
                    Name = tenderDto.tenderName,
                    StartDate = DateTime.Now,
                    EndDate = endDate,
                    TenderMedications = GetTenderMedicationsFromDto(tenderDto)
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static List<TenderMedication> GetTenderMedicationsFromDto(TenderDto tenderDto)
        {
            List<TenderMedication> tenderMedications = new List<TenderMedication>();
            foreach (var medication in tenderDto.medications)
            {
                tenderMedications.Add(new TenderMedication { MedicationName = medication.medicationName, Quantity = medication.quantity });
            }

            return tenderMedications;
        }
    }
}

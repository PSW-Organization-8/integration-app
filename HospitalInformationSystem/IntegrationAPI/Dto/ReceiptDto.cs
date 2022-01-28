using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class ReceiptDto
    {
        public string MedicineName { get; set; }
        public int Amount { get; set; }
        public string Diagnosis { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime Date { get; set; }

        public long PharmacyId { get; set; }

        public ReceiptDto()
        {

        }

        public ReceiptDto(string medecineName, int amount, string diagnosis, string doctor, string patient, DateTime date, long pharmacyId)
        {
            MedicineName = medecineName;
            Amount = amount;
            Diagnosis = diagnosis;
            Doctor = doctor;
            Patient = patient;
            Date = date;
            PharmacyId = pharmacyId;
        }
    }
}

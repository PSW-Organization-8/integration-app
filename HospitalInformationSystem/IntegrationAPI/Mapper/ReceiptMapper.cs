using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class ReceiptMapper
    {
        public static Receipt ReceiptToReceiptDto(ReceiptDto receiptDto) {
            return new Receipt { MedicineName = receiptDto.MedicineName, Amount = receiptDto.Amount, Date = receiptDto.Date, Diagnosis = receiptDto.Diagnosis, Doctor = receiptDto.Doctor, Patient = receiptDto.Patient};
        }
    }
}

using IntegrationAPI.Connection;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dto;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationClassLib.Pharmacy.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.IntegrationTests
{
    public class ReceiptTests
    {
        /*[Fact]
        public void Receipt_successfully_sent() {
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            IReceiptService receiptService = new ReceiptService();
            ReceiptController receiptController = new ReceiptController(receiptService, pharmacyService, new PharmacySFTPConnection(), new PharmacyHTTPConnection());

            ReceiptDto receiptDto = new ReceiptDto{ MedicineName = "Synthroid", Amount = 2, Diagnosis = "Grip", Doctor = "Filip Petrovic", Patient = "Petar Maric", PharmacyId = 1, Date = DateTime.Today };
            var ret =  receiptController.SaveReceipt(receiptDto);

            Assert.IsType<OkResult>(ret);
        }

        [Fact]
        public void Medication_not_available()
        {
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            IReceiptService receiptService = new ReceiptService();
            ReceiptController receiptController = new ReceiptController(receiptService, pharmacyService, new PharmacySFTPConnection(), new PharmacyHTTPConnection());

            ReceiptDto receiptDto = new ReceiptDto { MedicineName = "Brufen", Amount = 2, Diagnosis = "Grip", Doctor = "Filip Petrovic", Patient = "Petar Maric", PharmacyId = 1, Date = DateTime.Today };
            var ret = receiptController.SaveReceipt(receiptDto);

            Assert.IsType<BadRequestResult>(ret);
        }*/

    }
}

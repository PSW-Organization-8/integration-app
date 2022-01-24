using IntegrationAPI.Connection;
using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationClassLib.Pharmacy.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService receiptService;
        private readonly PharmacyService pharmacyService;
        private readonly IPharmacySFTPConnection sFTPConnection;
        private readonly IPharmacyHTTPConnection hTTPConnection;

        public ReceiptController(IReceiptService receiptService, PharmacyService pharmacyService, IPharmacySFTPConnection sFTPConnection, IPharmacyHTTPConnection hTTPConnection)
        {
            this.receiptService = receiptService;
            this.pharmacyService = pharmacyService;
            this.hTTPConnection = hTTPConnection;
            this.sFTPConnection = sFTPConnection;
        }

        [HttpPost]
        [Route("save_receipt")]
        public IActionResult SaveReceipt(Dto.ReceiptDto receipt)
        {
            Pharmacy pharmacy = pharmacyService.GetById(receipt.PharmacyId);
            if (hTTPConnection.MedicationQuantityExists(receipt.MedicineName, receipt.Amount, pharmacy) == false) { return BadRequest(); }
            string path = receiptService.CreateReceipt(ReceiptMapper.ReceiptToReceiptDto(receipt), pharmacy);
            if (pharmacy.Sftp == true)
            {
                sFTPConnection.SendReceiptToPharmacy(path);
                return hTTPConnection.DownloadReceiptToPharmacy(pharmacy, receipt);
            }
            else
            {
                if(!hTTPConnection.SendQRCodeToPharmacy(pharmacy, receipt, path)) return StatusCode(500, "Error! Receipt not sent to pharmacy!");
                return Ok();
            }
    
        }
    }
}

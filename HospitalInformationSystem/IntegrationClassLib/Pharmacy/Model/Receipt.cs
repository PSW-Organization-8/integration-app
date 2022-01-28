using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Model
{
    public class Receipt:Entity
    {
        public string MedicineName { get; set; }
        public int Amount { get; set; }
        public string Diagnosis { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime Date { get; set; }

        public Receipt() { }

        public override string GenerateStringForPdf()
        {
            string content = "\n\n\n Medication name: " + MedicineName + "\n Quantity: " + Amount + "\n Date of prescription: " + Date + "\n\n";
            content += "Prescribed to patient: " +Patient + "\n By doctor " +Doctor;
            return content; 
        }

        public Bitmap GenerateQRCode() {
            string qrText = GenerateStringForPdf();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }
    }
}

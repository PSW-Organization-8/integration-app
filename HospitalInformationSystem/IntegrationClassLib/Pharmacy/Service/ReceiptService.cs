using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service.Interface;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Service
{
    public class ReceiptService: IReceiptService
    {

        public string CreateReceipt(Receipt receipt, Pharmacy.Model.Pharmacy pharmacy)
        {
            string filePath = Directory.GetCurrentDirectory();
            string[] name = receipt.Patient.Split(" ");
            string fileName = "Receipt"+ name[0]+ name[1]+".pdf";
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString(WriteContent(receipt), new PdfFont(PdfFontFamily.Helvetica, 11f), new PdfSolidBrush(Color.Black), 10, 10);
            StreamWriter File = new StreamWriter(Path.Combine(filePath, fileName), true);
            doc.SaveToStream(File.BaseStream);

            File.Close();
            doc.Close();

            return Path.Combine(filePath, fileName);

        }

        private string WriteContent(Receipt receipt)
        {
            string content = "\n\n\n Medication name: " + receipt.MedicineName + "\n Quantity: " + receipt.Amount + "\n Date of prescription: " + receipt.Date + "\n\n";
            content += "Prescribed to patient: " + receipt.Patient + "\n By doctor " + receipt.Doctor;
            return content;
        }
    }
}

using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service.Interface;
using QRCoder;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
            DateTime dateTime = receipt.Date;
            string fileName = "Receipt" + name[0] + name[1] + dateTime.Year + dateTime.DayOfYear + dateTime.Hour + dateTime.Minute + dateTime.Second+ ".pdf";
            string path = Path.Combine(filePath, fileName);
            if (pharmacy.Sftp == true) {
                return CreatePdfReceipt(receipt, path);
            }
            fileName = "Receipt" + name[0] + name[1] + ".jpg";
            string pathQR = Path.Combine(filePath, fileName);
            return CreateQRCode(receipt, pathQR, path); ;

        }


        private string CreateQRCode(Receipt receipt, string pathImage, string pathPdf) {
            Bitmap qrCodeImage = receipt.GenerateQRCode();
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(pathImage, FileMode.Create, FileAccess.ReadWrite))
                {
                    qrCodeImage.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return SaveToPdf(pathImage, pathPdf); 
        }

        private string SaveToPdf(string imagePath, string pdfPath) {
            PdfDocument doc = new PdfDocument();
            Image image = Image.FromFile(imagePath);
            int width = image.Width;
            int height = image.Height;
            float schale = 0.4f;
            Size size = new Size((int)(width * schale), (int)(height * schale));
            Bitmap schaleImage = new Bitmap(image, size);
            PdfImage pdfImage = PdfImage.FromImage(schaleImage);
            PdfPageBase page0 = doc.Pages.Add();
            PointF position = new PointF((page0.Canvas.ClientSize.Width - schaleImage.Width) / 2, 210);
            page0.Canvas.SetTransparency(0.5f);
            page0.Canvas.DrawImage(pdfImage, position);
            page0.Canvas.SetTransparency(1.0f);
            StreamWriter File = new StreamWriter(pdfPath, true);
            doc.SaveToStream(File.BaseStream);

            File.Close();
            doc.Close();
            return pdfPath;

        }


        private string CreatePdfReceipt(Receipt receipt, string path) {
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString(receipt.GenerateStringForPdf(), new PdfFont(PdfFontFamily.Helvetica, 11f), new PdfSolidBrush(Color.Black), 10, 10);
            StreamWriter File = new StreamWriter(path, true);
            doc.SaveToStream(File.BaseStream);

            File.Close();
            doc.Close();

            return path;
        }
    }
}

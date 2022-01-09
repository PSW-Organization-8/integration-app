using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Repository.MedicationRepo;
using Renci.SshNet;
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
   public class MedicationConsumptionService
    {
        private readonly IMedicationConsumptionRepository medicationConsumptionRepository;

        public MedicationConsumptionService(IMedicationConsumptionRepository medicationConsumptionRepository)
        {
            this.medicationConsumptionRepository = medicationConsumptionRepository;
        }

        public Model.MedicationConsumption Add(Model.MedicationConsumption medicationConsumption)
        {
            return medicationConsumptionRepository.Create(medicationConsumption);
        }

        public List<Model.MedicationConsumption> GetAll()
        {
            return medicationConsumptionRepository.GetAll();
        }

        public void CreateReport(MedicationConsumptionDuration duration)
        {
            String filePath = Directory.GetCurrentDirectory();
            String fileName = "MedicationConsumptionReport.pdf";
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString(WriteContent(duration), new PdfFont(PdfFontFamily.Helvetica, 11f), new PdfSolidBrush(Color.Black),10, 10);
            if (System.IO.File.Exists(Path.Combine(filePath, fileName)))
            {
                System.IO.File.Delete(Path.Combine(filePath, fileName));
            }
            StreamWriter File = new StreamWriter(Path.Combine(filePath, fileName), true);
            doc.SaveToStream(File.BaseStream);
           // File.Write(WriteContent(duration));

            File.Close();
            doc.Close();

            SendReport(Path.Combine(filePath, fileName));

        }
        public string WriteContent(MedicationConsumptionDuration duration)
        {
            string content = "\n\n\nThis is a  report on medication consumption from " + duration.DurationStart.Date + " to " + duration.DurationEnd.Date + "\n\n\n\n";
            List<MedicationConsumption> medicationConsumptions = AllMedicationConsumptionInDuration(duration);
            foreach(MedicationConsumption medication in medicationConsumptions)
            {
                content += medication.GenerateStringForPdf();
            }
            content += WriteTotalMedicationConsumption(duration);
            return content;
        }

        public List<MedicationConsumption> GetAllMedication(MedicationConsumptionDuration duration)
        {
            List<MedicationConsumption> medicationConsumptions = AllMedicationConsumptionInDuration(duration);
            List<MedicationConsumption> medications = new List<MedicationConsumption>();
            foreach(MedicationConsumption medication in medicationConsumptions)
            {
                if(!isExist(medication.MedicineName,medications))
                {
                    MedicationConsumption newMedicationConsumption = new MedicationConsumption(medication.MedicineID,medication.MedicineName,medication.DateTime, medication.Quantity);
                    medications.Add(newMedicationConsumption);
                }
                
            }
            return medications;
        }

        public List<MedicationConsumption> TotalQunatityMedicationConsumption(List<MedicationConsumption> medicationConsumptions, MedicationConsumptionDuration duration)
        {
            List<MedicationConsumption> medications = AllMedicationConsumptionInDuration(duration);
            List<MedicationConsumption> newMedicationConsumptions = new List<MedicationConsumption>();
            foreach(MedicationConsumption medication in medicationConsumptions)
            {
                if(!isExist(medication.MedicineName,newMedicationConsumptions))
                {
                    double totalQuantity = TotalQuantityForOneMedication(medication, medications);
                    MedicationConsumption newMedicationConsumption = new MedicationConsumption(medication.MedicineName, totalQuantity);
                    newMedicationConsumptions.Add(newMedicationConsumption);
                }
            }

            return newMedicationConsumptions;
        }
        public string WriteTotalMedicationConsumption(MedicationConsumptionDuration duration)
        {
            List<MedicationConsumption> medications = TotalQunatityMedicationConsumption(GetAllMedication(duration), duration);
            string content = "\n\n Total medication consumption: \n\n";
            foreach (MedicationConsumption medication in medications)
            {
                content += medication.GenerateStringForPdfWithoutDate();
            }
            return content;

        }
        public double TotalQuantityForOneMedication(MedicationConsumption medicationConsumption, List<MedicationConsumption> medicationConsumptions)
        {
            double quantity = 0;
            foreach (MedicationConsumption medication in medicationConsumptions)
            {
                if (medication.MedicineName.Equals(medicationConsumption.MedicineName))
                {
                    quantity += medication.Quantity;
                }
            }
            return quantity;
        }

        public bool isExist(string medicationName, List<MedicationConsumption> medicationConsumptions)
        {
            foreach(MedicationConsumption medication in medicationConsumptions)
            {
                if(medication.MedicineName.Equals(medicationName))
                {
                    return true;
                }
            }
            return false;
        }
        public List<MedicationConsumption> AllMedicationConsumptionInDuration(MedicationConsumptionDuration duration)
        {

            List<MedicationConsumption> medicationConsumptions = new List<MedicationConsumption>();
            List<MedicationConsumption> allMedicationConsumptions = GetAll();
            foreach(MedicationConsumption medication in allMedicationConsumptions)
            {
                if (DateTime.Compare(duration.DurationStart,medication.DateTime.Date)<=0 && DateTime.Compare(duration.DurationEnd, medication.DateTime.Date) >=0)
                {
                    medicationConsumptions.Add(medication);
                }
            }    
            return medicationConsumptions;
        }

        public void SendReport(String filePath)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();
                using (Stream stream = File.OpenRead(filePath))
                {
                    client.UploadFile(stream, @"\public\" + Path.GetFileName(filePath), null);
                }
                client.Disconnect();
            }
        }



    }
}

using IntegrationClassLib.Pharmacy.Model;
using Renci.SshNet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Service
{
    public class MedicationSpecificationService
    {
        public MedicationSpecificationService()
        {
           
        }

        public void GetSpecificationnReport(String medicationName)
        {
            String fileName = "MedicationSpecification_" + medicationName + ".pdf";
            String localFile = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            String serverFile = @"\public\" + fileName;

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();
                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream, null);
                }
                client.Disconnect();
            }
        }
    }
}

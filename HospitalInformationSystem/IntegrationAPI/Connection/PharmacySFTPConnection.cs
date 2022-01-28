using IntegrationAPI.Connection.Interface;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection
{
    public class PharmacySFTPConnection : IPharmacySFTPConnection
    {
        public void SendReceiptToPharmacy(string path)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();

                using (Stream stream = System.IO.File.OpenRead(path))
                {
                    client.UploadFile(stream, @"\public\" + Path.GetFileName(path), null);
                }
                client.Disconnect();
            }
        }
    }
}

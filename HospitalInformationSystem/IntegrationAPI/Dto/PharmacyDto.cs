using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class PharmacyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public String ApiKey { get; set; }

        public String Url { get; set; }

        public String Port { get; set; }

        public String Notes { get; set; }

        public String Base64Image { get; set; }
        public bool ComunicateWithGrpc { get; set; }

        public bool ComunicateWithSftp { get; set; }
        public string EmailAddress { get; set; }

        public PharmacyDto() { }

        public PharmacyDto(long id, string name, string apiKey, string url, string port, string notes, string base64Image, bool grpc, bool sftp, string emailAddress)
        {
            Id = id;
            Name = name;
            ApiKey = apiKey;
            Url = url;
            Port = port;
            Notes = notes;
            Base64Image = base64Image;
            ComunicateWithGrpc = grpc;
            ComunicateWithSftp = sftp;
            EmailAddress = emailAddress;
        }
    }
}

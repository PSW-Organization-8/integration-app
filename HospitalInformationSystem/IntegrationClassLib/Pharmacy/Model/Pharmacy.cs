using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Model
{
    public class Pharmacy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public String ApiKey { get; set; }

        public String Url { get; set; }

        public String Port { get; set; }
        public bool ComunicateWithGrpc { get; set; }

        public bool Sftp { get; set; }

        public String Notes { get; set; }

        public String Base64Image { get; set; }
        public String EmailAddress { get; set; }

        public Pharmacy(){}

        public Pharmacy(string name, string apiKey, string url, string port, bool comunicateWithGrpc=false)
        {
            Name = name;
            ApiKey = apiKey;
            Url = url;
            Port = port;
            ComunicateWithGrpc = comunicateWithGrpc;
        }

        public Pharmacy(long id, string name, string apiKey, string url, string port, string notes)
        {
            Id = id;
            Name = name;
            ApiKey = apiKey;
            Url = url;
            Port = port;
            Notes = notes;
        }

        public Pharmacy(long id, string name, string apiKey, string url, string port, string notes, string base64Image, bool grpc)
        {
            Id = id;
            Name = name;
            ApiKey = apiKey;
            Url = url;
            Port = port;
            Notes = notes;
            Base64Image = base64Image;
            ComunicateWithGrpc = grpc;
        }

        public Pharmacy(long id, string name, string apiKey, string url, string port, string notes, string base64Image, bool grpc, bool sftp, string emailAddress)
        {
            Id = id;
            Name = name;
            ApiKey = apiKey;
            Url = url;
            Port = port;
            Notes = notes;
            Base64Image = base64Image;
            ComunicateWithGrpc = grpc;
            Sftp = sftp;
            EmailAddress = emailAddress;
        }
    }
}

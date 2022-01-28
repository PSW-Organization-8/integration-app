using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Model
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ObjectionId { get; set; }
        public string TextResponse { get; set; }

        public Response() { }

        public Response(string text, string objectionId)
        {

            TextResponse = text;
            ObjectionId = objectionId;

        }
    }
}

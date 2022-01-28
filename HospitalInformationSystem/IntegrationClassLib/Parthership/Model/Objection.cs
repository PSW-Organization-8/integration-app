using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Model
{
    public class Objection
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string PharmacyName { get; set; }
        public string TextObjection { get; set; }

        public Objection() { }

        public Objection(string text, string name) {

            TextObjection = text;
            PharmacyName = name;
            
        }


    }
}

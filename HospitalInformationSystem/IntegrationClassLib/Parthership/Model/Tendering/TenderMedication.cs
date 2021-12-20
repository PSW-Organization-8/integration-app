using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Model.Tendering
{
    public class TenderMedication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string MedicationName { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Tender")]
        public long TenderId { get; set; }

        public TenderMedication() { }

        public TenderMedication(long id, string medicationName, int quantity)
        {
            this.Id = id;
            this.MedicationName = medicationName;
            this.Quantity = quantity;
        }
    }
}

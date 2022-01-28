using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Tendering.Model
{
    public class PharmacyOfferComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string MedicationName { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        [ForeignKey("PharmacyOffer")]
        public long PharmacyOfferId { get; set; }


        public PharmacyOfferComponent() { }
    }
}

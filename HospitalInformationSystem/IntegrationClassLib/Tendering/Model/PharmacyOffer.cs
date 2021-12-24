using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Tendering.Model
{
    public class PharmacyOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long OfferIdInPharmacy { get; set; }
        public long PharmacyId { get; set; }
        public long TenderId { get; set; }
        public long TenderIdInHospital { get; set; }
        public string PharmacyName { get; set; }
        public DateTime TimePosted { get; set; }
        public virtual IEnumerable<PharmacyOfferComponent> Components { get; set; }

        public PharmacyOffer() { }

    }
}

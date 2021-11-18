
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IntegrationClassLib.Pharmacy.Model
{
    public class Medication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MedicineID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

    }    
}

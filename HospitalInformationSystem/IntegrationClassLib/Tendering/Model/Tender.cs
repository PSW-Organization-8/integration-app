using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationClassLib.Tendering.Model
{
    public class Tender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string HospitalName { get; set; } = "Bolnica1";

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsAceptedOffer { get; set; } = false;

        public List<TenderMedication> TenderMedications { get; set; }

        public Tender()
        {
        }
    }
}
using IntegrationClassLib.Model;
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

        public DateRange DateRange { get; set; }

        public bool IsAceptedOffer { get; set; } = false;

        private List<TenderMedication> _tenderMedications = new List<TenderMedication>();

        public IReadOnlyCollection<TenderMedication> TenderMedications => _tenderMedications.AsReadOnly();


        [ForeignKey("PharmacyOffer")]
        public long WinnerOfferId { get; set; }

        public Tender()
        {
        }

        public Tender(string name, DateRange dateRange, List<TenderMedication> medication) {
            this._tenderMedications = medication;
            this.Name = name;
            this.DateRange = dateRange;
        
        }


        public bool AddTenderMedication(TenderMedication medication) {
            foreach (TenderMedication med in this.TenderMedications) {
                if (med.MedicationName.Equals(medication.MedicationName)) {
                    med.Quantity = med.Quantity + medication.Quantity;
                    return true;
                }
            }
            this._tenderMedications.Add(medication);
            return false;
        }

        public void AcceptOffer(long pharmacyOfferId) {
            this.IsAceptedOffer = true;
            this.WinnerOfferId = pharmacyOfferId;
            if (DateRange.End == null)
            {
                this.DateRange = new DateRange(DateRange.Start, DateTime.Now);
            }
        }
    }
}
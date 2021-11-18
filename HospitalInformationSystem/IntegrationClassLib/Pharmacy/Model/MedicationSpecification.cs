using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Model
{
    public class MedicationSpecification
    {
        public string PharmacyName { get; set; }
        public string MedicationName { get; set; }

        public MedicationSpecification()
        {
        }

        public MedicationSpecification(string pharmacyName, string medicationName)
        {
            PharmacyName = pharmacyName;
            MedicationName = medicationName;
        }

    }
}

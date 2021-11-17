using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class MedicationQuantityDTO
    { 
        public string Name { get; set; }
        public int Quantity { get; set; }

        public string Pharmacy { get; set; }

        public MedicationQuantityDTO() { }

        public MedicationQuantityDTO(string name, int quantity, string pharmacy) {
            Name = name;
            Quantity = quantity;
            Pharmacy = pharmacy;
        }
    }
}

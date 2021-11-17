using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class PharmaciesWithAvailableMedicineDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string AdressNumber { get; set; }

        public PharmaciesWithAvailableMedicineDTO() { }

        public PharmaciesWithAvailableMedicineDTO(long id, string name, string city, string adress, string adressNumber)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
            this.Adress = adress;
            this.AdressNumber = adressNumber;
        }
    }
}

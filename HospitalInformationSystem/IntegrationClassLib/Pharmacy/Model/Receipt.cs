using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Model
{
    public class Receipt
    {
        public string MedicineName { get; set; }
        public int Amount { get; set; }
        public string Diagnosis { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime Date { get; set; }

        public Receipt() { }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Model
{

    public class MedicationConsumption: Entity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MedicineID { get; set; }
        public string MedicineName { get; set; }
       
        public DateTime DateTime { get; set; }

        public double Quantity { get; set; }

        public MedicationConsumption()
        {

        }
        public MedicationConsumption(string medicineName,double quantity)
        {
            this.MedicineName = medicineName;
            this.Quantity = quantity;
        }
        public MedicationConsumption(long id, string name, DateTime dateTime,double quantity)
        {
            MedicineID = id;
            MedicineName = name;
            DateTime = dateTime;
            Quantity = quantity;
        }

        public override string GenerateStringForPdf()
        {
            string content = "Medication name: " + this.MedicineName + "\n Quantity: " + this.Quantity + "\n Date: " + this.DateTime.Date + "\n\n";
            content += "--------------------------------------------------------------------------------------------\n\n";
            return content;
        }

        public string GenerateStringForPdfWithoutDate() {

            string content = "Medication name: " + this.MedicineName + "\n Quantity: " + this.Quantity + "\n\n\n";
            content += "--------------------------------------------------------------------------------------------\n\n";
            return content;
        }
    }
}

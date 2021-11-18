using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Service.Interface
{
    public interface IMedicationService
    {
        List<Medication> GetAll();
        Medication GetMedicationByName(string name);

        Medication Get(long id);

        Medication Create(Medication newMedication);

        Boolean Delete(long id);

        Boolean Update(Medication medication);

        Medication AddMedicationFromPharmacy(Medication medication);
    }
}

using IntegrationClassLib.Pharmacy.Model;
using SIMS.Repositories;

namespace IntegrationClassLib.Pharmacy.Repository.MedicationRepo
{
    public interface IMedicationRepository : IGenericRepository<Medication, long>
    {
        Medication GetMedicationByName(string name);
    }
}

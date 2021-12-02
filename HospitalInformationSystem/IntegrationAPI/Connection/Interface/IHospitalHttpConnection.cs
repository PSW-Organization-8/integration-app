using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection.Interface
{
    public interface IHospitalHttpConnection
    {
        bool SaveMedication(MedicationDto newMedication, Pharmacy pharmacy, OrderMedicationDto orderMedicationDto);
    }
}

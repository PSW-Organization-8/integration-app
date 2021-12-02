using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection
{
    public class HospitalHttpConnection : IHospitalHttpConnection
    {
        public const string HospitalUrl = "http://localhost:16934/api/";

        public bool SaveMedication(MedicationDto newMedication, Pharmacy pharmacy, OrderMedicationDto orderMedicationDto)
        {
            RestClient restClientHospital = new RestClient(HospitalUrl + "Medcation/save_medication");
            RestRequest requestHospital = new RestRequest();

            requestHospital.AddJsonBody(newMedication);

            var dataHospital = restClientHospital.Post<IActionResult>(requestHospital);

            if (dataHospital.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            return true;
        }
    }
}

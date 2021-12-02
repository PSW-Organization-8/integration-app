using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Connection;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectionController : ControllerBase
    {
        private readonly ObjectionService objectionService;
        private readonly ResponseService responseService;
        private readonly PharmacyService pharmacyService;
        private readonly IPharmacyHTTPConnection hTTPConnection;

        public ObjectionController(ObjectionService objectionService, ResponseService responseService, PharmacyService pharmacyService, IPharmacyHTTPConnection hTTPConnection)
        {
            this.objectionService = objectionService;
            this.responseService = responseService;
            this.pharmacyService = pharmacyService;
            this.hTTPConnection = hTTPConnection;
        }

        [HttpGet]
        public List<ObjectionResponseDTO> GetAll()
        {
            return ObjectionMapper.ObjectionResponsesToObjectionResponseDTO(objectionService.GetAll(), responseService.GetAll());
        }
        [HttpPost]
        public Objection Add(ObjectionDTO objectionDTO)
        {
            Objection newObjection = objectionService.Add(ObjectionMapper.ObjectionDTOToObjection(objectionDTO));
            Pharmacy pharmacy = pharmacyService.GetByName(objectionDTO.PharmacyName);
            hTTPConnection.SendObjectionToPharmacy(pharmacy, newObjection);
            return newObjection;
        }

    }
}

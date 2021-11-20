using IntegrationAPI.Filters;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Service;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/[controller]")]
    public class ResponseController : ControllerBase
    {
        private readonly ObjectionService objectionService;
        private readonly ResponseService responseService;
        private readonly PharmacyService pharmacyService;

        public ResponseController(ObjectionService objectionService, ResponseService responseService, PharmacyService pharmacyService)
        {
            this.objectionService = objectionService;
            this.responseService = responseService;
            this.pharmacyService = pharmacyService;
        }

        [HttpPost]
        public Response Add(Response response)
        {
            HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKey);
            Objection objection = objectionService.GetObjection(long.Parse(response.ObjectionId));
            if (!objection.PharmacyName.Equals(pharmacyService.GetByApiKey(apiKey).Name)) {
                return null;
            }
            return responseService.Add(response);
        }


    }
}

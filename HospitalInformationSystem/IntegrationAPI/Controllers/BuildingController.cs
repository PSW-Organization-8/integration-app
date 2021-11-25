using IntegrationClassLib.Equipment.Service;
using IntegrationClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BuildingController : ControllerBase
    {
        private readonly BuildingService buildingService;
        public BuildingController(BuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        [HttpGet]
        public List<Building> GetAllBuildings()
        {
            return buildingService.GetAllBuildings();
        }

        [HttpPost]

        [Route("buildings")]

        [Route("createBuildings")]

        public Building CreateBuildings(Building building)
        {
            return buildingService.CreateBuildings(building);
        }

        [HttpPost]
        [Route("allBuildings")]
        public void CreateAllBuildings(List<IntegrationClassLib.SharedModel.Building> buildings)
        {
            buildingService.CreateAllBuildings(buildings);
        }

    }
}

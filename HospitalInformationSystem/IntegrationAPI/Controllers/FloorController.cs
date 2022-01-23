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

    public class FloorController : ControllerBase
    {
        private readonly FloorService floorService;
        public FloorController(FloorService floorService)
        {
            this.floorService = floorService;
        }

        [HttpGet]
        public List<Floor> GetAllFloors()
        {
            return floorService.GetAllFloors();
        }

        [HttpPost]
        [Route("createFloors")]
        public Floor CreateFloors(Floor floor)
        {
            return floorService.CreateFloors(floor);
        }

        [HttpPost]
        [Route("/api/allFloors")]
        public void CreateAllFloors(List<IntegrationClassLib.SharedModel.Floor> floors)
        {
            floorService.CreateAllFloors(floors);
        }
    }
}

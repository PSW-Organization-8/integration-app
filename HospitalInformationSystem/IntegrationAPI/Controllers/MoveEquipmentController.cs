using IntegrationClassLib.RelocationEquipment.Service;
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

    public class MoveEquipmentController : ControllerBase
    {
        private readonly MoveEquipmentService moveEquipmentService;
        public MoveEquipmentController(MoveEquipmentService moveEquipmentService)
        {
            this.moveEquipmentService = moveEquipmentService;
        }

        [HttpGet]
        public List<MoveEquipment> GetAllEquipments()
        {
            return moveEquipmentService.GetAllEquipments();
        }

        [HttpPost]
        [Route("/api/moveEquipments")]
        public MoveEquipment CreateEquipments(MoveEquipment moveEquipment)
        {
            return moveEquipmentService.CreateEquipments(moveEquipment);
        }

        [HttpPost]
        [Route("/api/moveAllEquipments")]
        public void CreateAllEquipments(List<IntegrationClassLib.SharedModel.MoveEquipment> moveEquipments)
        {
            moveEquipmentService.CreateAllEquipments(moveEquipments);
        }

        [HttpGet]
        [Route("/api/moveEquipment/{id}")]
        public MoveEquipment Get(long id)
        {
            return moveEquipmentService.Get(id);
        }
    }
}

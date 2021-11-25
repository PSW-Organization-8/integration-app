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

    public class EquipmentController : ControllerBase
    {


        private readonly EquipmentService equipmentService;
        public EquipmentController(EquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet]
        public List<Equipment> GetAllEquipments()
        {
            return equipmentService.GetAllEquipments();
        }

       [HttpPost]

        [Route("equipmentsst")]

        [Route("createEquipments")]

        public Equipment CreateEquipments(Equipment equipment)
        {
            return equipmentService.CreateEquipments(equipment);
        }

        [HttpPost]
        [Route("/api/allEquipments")]
        public void CreateAllEquipments(List<IntegrationClassLib.SharedModel.Equipment> equipments)
        {
           equipmentService.CreateAllEquipments(equipments);
        }

        [HttpGet]
        [Route("equipment/{id}")]
        public Equipment Get(long id)
        {
            return equipmentService.Get(id);
        }




    }
}

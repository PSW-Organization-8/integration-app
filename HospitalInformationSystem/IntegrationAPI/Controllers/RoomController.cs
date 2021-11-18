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

    public class RoomController : ControllerBase
    {

        private readonly RoomService roomService;
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public List<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }

        [HttpPost]
        [Route("createRooms")]
        public Room CreateRooms(Room room)
        {
            return roomService.CreateRooms(room);
        }

        [HttpPost]
        public void CreateAllRooms(List<IntegrationClassLib.SharedModel.Room> rooms)
        {
            roomService.CreateAllRooms(rooms);
        }
    }
}

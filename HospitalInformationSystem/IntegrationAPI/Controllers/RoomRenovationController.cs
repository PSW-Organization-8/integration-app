using IntegrationAPI.Dto;
using IntegrationClassLib.Equipment.Service;
using IntegrationClassLib.RoomRenovation.Service;
using IntegrationClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoomRenovationController : ControllerBase
    {
        private readonly RoomRenovationService RoomRenovationService;

        public RoomRenovationController(RoomRenovationService roomRenovationService)
        {
            this.RoomRenovationService = roomRenovationService;
        }

        [HttpGet]
        [Route("availableRooms/{id}")]
        public List<Room> FindRoomsAvailableForMerging(long id)
        {
            return RoomRenovationService.FindRoomsAvailableForMerging(id);
        }

        [HttpPost]
        [Route("splitRoom")]
        void SplitRoom(SplitRoomDTO splitRoomDTO)
        {
            RoomRenovationService.SplitRoom(splitRoomDTO.Room, splitRoomDTO.Name);
        }

        [HttpPost]
        [Route("mergeRooms")]
        void MergeRooms(MergeRoomsDTO mergeRoomsDTO)
        {
            RoomRenovationService.MergeRooms(mergeRoomsDTO.Room1, mergeRoomsDTO.Room2, mergeRoomsDTO.Name);
        }
    }
}

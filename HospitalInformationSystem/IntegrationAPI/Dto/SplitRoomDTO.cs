using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class SplitRoomDTO
    {
        public Room Room { get; set; }
        public string Name { get; set; }

        public SplitRoomDTO() { }

        public SplitRoomDTO(Room room, string name)
        {
            Room = room;
            Name = name;
        }
    }
}

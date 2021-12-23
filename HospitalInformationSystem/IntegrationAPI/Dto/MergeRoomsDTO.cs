using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class MergeRoomsDTO
    {
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }
        public string Name { get; set; }
        public MergeRoomsDTO() { }

        public MergeRoomsDTO(Room room1, Room room2, string name)
        {
            Room1 = room1;
            Room2 = room2;
            Name = name;
        }
    }
}

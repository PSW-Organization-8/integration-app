using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class RoomDTO
    {
        public string RenovationType { get; set; }
        
        public long RenovationRoomID { get; set; }

        public DateTime RenovationTime { get; set; }

        public string RenovationDuration { get; set; }

        public string Room1Name { get; set; }

        public string Room2Name { get; set; }

        public string Room1Descriprtion { get; set; }

        public string Room2Description { get; set; }

        public long NewEquipmentID { get; set; }
    }
}

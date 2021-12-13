using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class MoveEquipmentDTO
    {
        public long IDeq { get; set; }

        public long IDroom { get; set; }

        public double Amount { get; set; }

        public long DestinationRoom { get; set; }

        public DateTime RelocationTime { get; set; }

        public string Duration { get; set; }

    }
}

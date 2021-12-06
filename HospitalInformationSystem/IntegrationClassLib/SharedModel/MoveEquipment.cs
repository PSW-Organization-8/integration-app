using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class MoveEquipment
    {
        public long ID { get; set; }

        public Equipment equipment { get; set; }

        public double amount { get; set; }
        public Room destinationRoom { get; set; }

        public DateTime relocationTime { get; set; }

        public string duration { get; set; }


        public MoveEquipment()
        {

        }

        public MoveEquipment(long id, Equipment eq, Room destination, DateTime time, string durationRel, double amountt)
        {
            this.ID = id;
            this.equipment= eq;
            this.destinationRoom = destination;
            this.relocationTime = time;
            this.duration = durationRel;
            this.amount = amountt;
        }
    }
}

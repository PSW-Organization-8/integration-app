using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class Appointment
    {

        public Appointment()
        {
        }

        public Appointment(long id, DateTime dateandTime, Room room)
        {
            ID = id;
            DateandTime = dateandTime;
            Room = room;
        }

        public DateTime DateandTime { get; set; }
        public Room Room { get; set; }

        public long ID { get; set; }


    }
}

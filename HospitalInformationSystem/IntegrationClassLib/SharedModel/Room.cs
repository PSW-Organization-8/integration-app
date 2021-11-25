using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class Room
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Floor Floor { get; set; }

        public Room()
        {

        }


        public Room(string id, string name, Floor floor)
        {
            this.ID = id;
            this.Name = name;
            this.Floor = floor;
        }
    }
}

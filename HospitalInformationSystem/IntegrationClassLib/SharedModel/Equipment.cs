using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class Equipment
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Room Room { get; set; }

        public double Amount { get; set; }

        public Equipment()
        {

        }

        public Equipment(string id, string name, Room room, double amount)
        {
            this.ID = id;
            this.Name = name;
            this.Room = room;
            this.Amount = amount;
        }

    }
}

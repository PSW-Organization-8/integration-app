using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class Floor
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public Building Building { get; set; }

     
        public Floor()
        {

        }

        public Floor(long id, string name, Building building)
        {
            this.ID = id;
            this.Name = name;
            this.Building = building;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class Building
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Building()
        {
           
        }

        public Building(string id, string name)
        {
            this.ID = id;
            this.Name = name;
               
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class Building
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public Building()
        {
           
        }

        public Building(long id, string name)
        {
            this.ID = id;
            this.Name = name;
               
        }

    }
}

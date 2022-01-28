using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationClassLib.Pharmacy.Model
{
    public class Component
    {
        public string ID { get; set; }
        public string Name { get; set; }
        

        public Component()
        {
            ID = "";
            Name = "";
        }

        public Component(string ID, string Naziv)
        {
            this.ID = ID;
            this.Name = Naziv;
        }

        
    }
}

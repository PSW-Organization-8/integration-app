using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Model
{
    public abstract class Entity
    { 

        protected Entity()
        {
        }


        public abstract string GenerateStringForPdf();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class ObjectionDTO
    {
        public string PharmacyName { get; set; }
        public string TextObjection { get; set; }

        public ObjectionDTO()
        {
        }

        public ObjectionDTO(string text, string name) {
            PharmacyName = name;
            TextObjection = text;
        }
    }
}

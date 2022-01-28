using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class ObjectionResponseDTO
    {
        public string PharmacyName { get; set; }
        public string TextObjection { get; set; }

        public string TextResponse { get; set; }

        public ObjectionResponseDTO()
        {
        }

        public ObjectionResponseDTO(string textObjection, string name, string textResponse)
        {
            PharmacyName = name;
            TextObjection = textObjection;
            TextResponse = textResponse;
        }
    }
}

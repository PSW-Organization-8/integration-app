using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class TenderDto
    {
        public string tenderName { get; set; }
        public string complationDate { get; set; }
        public List<TenderMedicationDto> medications { get; set; }

        public TenderDto()
        {
        }
    }
}

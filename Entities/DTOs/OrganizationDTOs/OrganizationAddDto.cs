using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OrganizationDTOs
{
    public class OrganizationAddDto
    {
        public string TaxNumber { get; set; }
        public string OrganizationName { get; set; }
        public string? ContractYear { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? StreetAptNo { get; set; }
    }
}

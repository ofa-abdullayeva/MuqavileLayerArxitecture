using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OrganizationDTOs
{
    public class OrganizationGetDto: IDto
    {
        public int OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public string? TaxNumber { get; set; }
        public string? ContractYear { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? StreetAptNo { get; set; }


        public List<ContractMiniDto>? Contracts { get; set; }
    }


    public class ContractMiniDto
    {
        public int ContractId { get; set; }
        public string? ContractNumber { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? StartDate { get; set; }
    }

}


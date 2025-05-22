using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ContractDTOs
{
    public class ContractFilterDto
    {
        public string? ContractNumber { get; set; }
        public string? ContractYear { get; set; }
        public string? TaxNumber { get; set; }
        public int? OrganizationId { get; set; }
        public string? Subject { get; set; }
        public decimal? AmountMin { get; set; }
        public decimal? AmountMax { get; set; }
        public int? GuaranteeId { get; set; }
        public string GuaranteeName { get; set; }
        public int? AmountTypeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CategoryId { get; set; }
        public int? CategoryTypeId { get; set; }
        public int? ContractStatusId { get; set; }
    }
}

using System;

namespace Entities.DTOs.ContractDTOs
{
    public class ContractListDto
    {
        public int ContractId { get; set; }
        public string? ContractNumber { get; set; }
        public string? ContractYear { get; set; }
        public string? TaxNumber { get; set; }
        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public string? Subject { get; set; }

        public decimal? Amount { get; set; }
        public string? AmountTypeName { get; set; }
        public string? PaymentMethodName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryTypeName { get; set; }
        public string? GuaranteeName { get; set; }
        public string? StatusName { get; set; }
        public int AmountTypeId { get; set; }
        public int PaymentMethodId { get; set; }
       
        public int CategoryTypeId { get; set; }
        public int ContractStatusId { get; set; }
    }
}

﻿public class ContractUpdateViewModel
{
    public int ContractId { get; set; }

    public string ContractNumber { get; set; }
    public string ContractYear { get; set; }
    public string? TaxNumber { get; set; }
    public int OrganizationId { get; set; }

    public string? Subject { get; set; }
    public decimal? Amount { get; set; }
    public int? AmountTypeId { get; set; }
    public int? PaymentMethodId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? CategoryId { get; set; }
    public int? CategoryTypeId { get; set; }
    public int? ContractStatusId { get; set; }
    public int? GuaranteeId { get; set; }
    public string? Fine { get; set; }
    public string? Notes { get; set; }
}

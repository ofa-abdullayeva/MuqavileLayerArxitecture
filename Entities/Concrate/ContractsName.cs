using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class ContractsName: IEntity
{
    public int ContractId { get; set; }

    public string? ContractYear { get; set; }

    public string? ContractNumber { get; set; }

    public string? TaxNumber { get; set; }

    public string? OrganizationName { get; set; }

    public int? OrganizationId { get; set; }

    public int? OrganizationIdold { get; set; }

    public string? Subject { get; set; }

    public decimal? Amount { get; set; }

    public string? AmountTypeName { get; set; }

    public int? AmountTypeId { get; set; }

    public string? PaymentMethodName { get; set; }

    public int? PaymentMethodId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? CategoryName { get; set; }

    public int? CategoryId { get; set; }

    public string? CategoryTypeName { get; set; }

    public int? CategoryTypeId { get; set; }

    public string? ContractStatusName { get; set; }

    public int? ContractStatusId { get; set; }

    public string? GuaranteeName { get; set; }

    public int? GuaranteeId { get; set; }

    public string? Fine { get; set; }

    public string? Notes { get; set; }

    public string? Attachment { get; set; }

    public string? ContactsOrg { get; set; }

    public string? ContactsDim { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}

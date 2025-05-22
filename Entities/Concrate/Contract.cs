using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class Contract:IEntity
{
    public int ContractId { get; set; }

    public string? ContractYear { get; set; }

    public string? ContractNumber { get; set; }

    public string? TaxNumber { get; set; }

    public int? OrganizationId { get; set; }

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

    public byte[] SsmaTimeStamp { get; set; } = null!;

    public virtual AmountType? AmountType { get; set; }

    public virtual Category? Category { get; set; }

    public virtual CategoryType? CategoryType { get; set; }

    public virtual ICollection<ContactPersonsOrg> ContactPersonsOrgs { get; set; } = new List<ContactPersonsOrg>();

    public virtual ICollection<ContactPersonsSec> ContactPersonsSecs { get; set; } = new List<ContactPersonsSec>();

    public virtual ICollection<ContractAttachFile> ContractAttachFiles { get; set; } = new List<ContractAttachFile>();

    public virtual ContractStatus? ContractStatus { get; set; }

    public virtual ICollection<Extension> Extensions { get; set; } = new List<Extension>();

    public virtual Guarantee? Guarantee { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Organization? Organization { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }
}

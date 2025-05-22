using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class Invoice: IEntity
{
    public int InvoiceId { get; set; }

    public int? ContractId { get; set; }

    public string? InvoiceSerialNo { get; set; }

    public string? InvoiceNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? InvoiceAmount { get; set; }

    public int? AmountTypeId { get; set; }

    public virtual AmountType? AmountType { get; set; }

    public virtual Contract? Contract { get; set; }
}

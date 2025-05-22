using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class AmountType : IEntity
{
    public int AmountTypeId { get; set; }

    public string? AmountTypeName { get; set; }

    public string? AmountSymbol { get; set; }

    public string? AmountDescription { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}

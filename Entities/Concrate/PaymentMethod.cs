using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class PaymentMethod: IEntity
{
    public int PaymentMethodId { get; set; }

    public string? PaymentMethodName { get; set; }

    public string? PaymentMethodDescription { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

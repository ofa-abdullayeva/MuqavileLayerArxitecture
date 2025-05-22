using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class Guarantee: IEntity
{
    public int GuaranteeId { get; set; }

    public string? GuaranteeName { get; set; }

    public string? GuaranteeDescription { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

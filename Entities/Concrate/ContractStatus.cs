using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class ContractStatus: IEntity
{
    public int ContractStatusId { get; set; }

    public string? ContractStatusName { get; set; }

    public string? ContractStatusDescription { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

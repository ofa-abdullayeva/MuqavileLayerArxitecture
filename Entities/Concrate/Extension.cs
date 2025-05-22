using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class Extension: IEntity
{
    public int ExtensionId { get; set; }

    public int? ContractId { get; set; }

    public DateTime? CurrentEndDate { get; set; }

    public DateTime? NewEndDate { get; set; }

    public string? ExtensionReason { get; set; }

    public string? LinkFiles { get; set; }

    public string? LinkDelete { get; set; }

    public virtual Contract? Contract { get; set; }

    public virtual ICollection<ContractExtensionFile> ContractExtensionFiles { get; set; } = new List<ContractExtensionFile>();
}

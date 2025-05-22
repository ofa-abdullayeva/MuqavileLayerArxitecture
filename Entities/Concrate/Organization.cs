using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class Organization: IEntity
{
    public int OrganizationId { get; set; }

    public string? TaxNumber { get; set; }

    public string? OrganizationName { get; set; }

    public string? ContractYear { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? StreetAptNo { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

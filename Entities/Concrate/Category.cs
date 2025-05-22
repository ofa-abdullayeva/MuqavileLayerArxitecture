using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class Category:IEntity
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

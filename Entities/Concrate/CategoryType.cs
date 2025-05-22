using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class CategoryType :IEntity
{
    public int CategoryTypeId { get; set; }

    public string? CategoryTypeName { get; set; }

    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

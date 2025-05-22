using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class AccessLevel:IEntity
{
    public int AccessLevelId { get; set; }

    public string? AccessLevelName { get; set; }

    public string? Description { get; set; }
}

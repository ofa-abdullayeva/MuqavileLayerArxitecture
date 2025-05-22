using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class About :IEntity
{
    public string? AboutTheSystem { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}

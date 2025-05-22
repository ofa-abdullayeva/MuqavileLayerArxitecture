using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class DeleteLog: IEntity
{
    public int LogId { get; set; }

    public string? TableName { get; set; }

    public int? RecordId { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeleteTime { get; set; }
}

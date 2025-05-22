using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class ContractExtensionFile:IEntity
{
    public int FileId { get; set; }

    public string? FileName { get; set; }

    public string? FileType { get; set; }

    public byte[]? FileData { get; set; }

    public int? ContractId { get; set; }

    public int? ExtensionId { get; set; }

    public virtual Extension? Extension { get; set; }
}

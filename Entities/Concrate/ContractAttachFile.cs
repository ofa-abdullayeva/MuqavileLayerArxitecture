using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class ContractAttachFile:IEntity
{
    public int FileId { get; set; }

    public string? FileName { get; set; }

    public string? FileType { get; set; }

    public byte[]? FileData { get; set; }

    public int? ContractId { get; set; }

    public virtual Contract? Contract { get; set; }
}

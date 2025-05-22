using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class User: IEntity
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? AccessLevelId { get; set; }

    public string? BackupFilePath { get; set; }

    public string? ServerName { get; set; }

    public string? DataBaseName { get; set; }

    public virtual AccessLevel? AccessLevel { get; set; }
}

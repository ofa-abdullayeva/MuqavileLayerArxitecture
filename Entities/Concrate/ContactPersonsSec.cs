using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class ContactPersonsSec:IEntity
{
    public int SecId { get; set; }

    public int? ContractId { get; set; }

    public int? ContactId { get; set; }

    public virtual Contract? Contract { get; set; }
}

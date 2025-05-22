using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrate;

public partial class ContactPersonsOrg:IEntity
{
    public int ContactId { get; set; }

    public int? ContractId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? JobPosition { get; set; }

    public string? MobilePhone1 { get; set; }

    public string? MobilePhone2 { get; set; }

    public string? OfficePhone { get; set; }

    public string? EmailAddress { get; set; }

    public virtual Contract? Contract { get; set; }
}

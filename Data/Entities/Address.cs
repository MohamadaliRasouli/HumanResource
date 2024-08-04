using System;
using System.Collections.Generic;
using HumanResource.Data.Entities;

namespace HumanResource.Data.Entities;

public  class Address
{
    public int AddressId { get; set; }

    public int PersonId { get; set; }

    public string? Address1 { get; set; }

    public virtual Person CreatePersonModel { get; set; } = null!;
}

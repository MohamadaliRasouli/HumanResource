using System;
using System.Collections.Generic;

namespace HumanResource.Data.Database;

public partial class Address
{
    public int AddressId { get; set; }

    public int PersonId { get; set; }

    public string? Address1 { get; set; }

    public virtual Person Person { get; set; } = null!;
}

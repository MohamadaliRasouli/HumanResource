﻿using System;
using System.Collections.Generic;

namespace HumanResource.Data.Database;

public partial class Address
{
    public int AddressId { get; set; }

    public int PersonId { get; set; }

    public string? Address1 { get; set; }

    public int PostalCode { get; set; }

    public string? StreetName { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}

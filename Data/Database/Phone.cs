using System;
using System.Collections.Generic;

namespace HumanResource.Data.Database;

public partial class Phone
{
    public int PhoneId { get; set; }

    public int PersonId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}

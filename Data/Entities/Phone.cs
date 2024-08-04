using System;
using System.Collections.Generic;
using HumanResource.Data.Entities;

namespace HumanResource.Data.Entities;

public partial class Phone
{
    public int PhoneId { get; set; }

    public int PersonId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual Person CreatePersonModel { get; set; } = null!;
}

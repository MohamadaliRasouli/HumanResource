using System;
using System.Collections.Generic;
using HumanResource.Api.Models.person;

namespace HumanResource.Api.Models.address;

public partial class CreateAddressModel
{
    public int PersonId { get; set; }
    public string? Address1 { get; set; }

    public int PostalCode { get; set; }

    public string? StreetName { get; set; }
}
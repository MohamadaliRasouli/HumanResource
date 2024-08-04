using System;
using System.Collections.Generic;

namespace HumanResource.Api.Models.person;

public partial class CreatePersonModel
{

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string NationalIdentity { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public IFormFile Photo { get; set; } = null!;

   
}

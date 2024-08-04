using System.ComponentModel.DataAnnotations;

namespace HumanResource.Api.Models.person;

public partial class CreatePersonModel
{
    [Required(ErrorMessage = "نام کاربری رو وارد کنید ")]
    [Display(Name = "نام")]
    public required string Name { get; set; }

    public required string LastName { get; set; }

    public string NationalIdentity { get; set; }

    public DateTime BirthDate { get; set; }

    public IFormFile Photo { get; set; } = null!;

   
}

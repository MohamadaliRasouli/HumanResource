namespace HumanResource.Api.Models.person;

public class UpdatePersonModel
{
    
    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string NationalIdentity { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public IFormFile Photo { get; set; } = null!;
    

}
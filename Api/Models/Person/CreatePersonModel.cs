namespace HumanResource.Api.Models.Person;

public class CreatePersonModel
{
    public required string Name { get; set; }

    public required string LastName { get; set; }

    public required string NationalIdentity { get; set; }

    public DateTime BirthDate { get; set; }
}
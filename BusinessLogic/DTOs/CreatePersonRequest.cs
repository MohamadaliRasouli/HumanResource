namespace HumanResource.BusinessLogic.DTOs;

public class CreatePersonRequest
{
    public required string Name { get; set; }

    public required string LastName { get; set; }

    public required string NationalIdentity { get; set; }

    public required DateTime BirthDate { get; set; }
}
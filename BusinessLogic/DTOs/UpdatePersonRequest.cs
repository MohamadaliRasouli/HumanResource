namespace HumanResource.BusinessLogic.DTOs;

public class UpdatePersonRequest
{
    public required string Name { get; set; }

    public required string LastName { get; set; }

    public required string NationalIdentity { get; set; }

    public required DateTime BirthDate { get; set; }
    
    public byte[] Photo { get; set; } = null!;
    
}
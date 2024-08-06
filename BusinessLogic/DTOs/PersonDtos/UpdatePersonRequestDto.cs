using Microsoft.AspNetCore.Http;

namespace HumanResource.BusinessLogic.DTOs;

public class UpdatePersonRequestDto
{
    public required string Name { get; set; }

    public required string LastName { get; set; }

    public required string NationalIdentity { get; set; }

    public required DateTime BirthDate { get; set; }
    
    public IFormFile Photo { get; set; } = null!;
    
}
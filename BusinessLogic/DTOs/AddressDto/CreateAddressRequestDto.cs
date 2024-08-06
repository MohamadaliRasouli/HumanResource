namespace HumanResource.BusinessLogic.DTOs.AddressDto;

public class CreateAddressRequestDto
{
    public int PersonId { get; set; }
    public string? Address1 { get; set; }

    public int PostalCode { get; set; }

    public string? StreetName { get; set; }
}
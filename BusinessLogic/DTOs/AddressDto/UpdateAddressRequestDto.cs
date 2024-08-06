namespace HumanResource.BusinessLogic.DTOs.AddressDto;

public class UpdateAddressRequestDto
{
    
    public string? Address1 { get; set; }

    public int PostalCode { get; set; }

    public string? StreetName { get; set; }
}
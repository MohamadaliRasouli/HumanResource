using HumanResource.BusinessLogic.DTOs.AddressDto;
using HumanResource.Data.Database;

namespace HumanResource.BusinessLogic.Contract;

public interface IAddressService
{
    Task<List<AddressListDto>> List(CancellationToken ct);
    
    Task<GetAddressDto> GetAddressByPersonId(int id , CancellationToken ct);

    Task CreateByPersonId(CreateAddressRequestDto  address , CancellationToken cs);

    Task<Address> UpdateByPersonId(int id , UpdateAddressRequestDto address, CancellationToken cs);

    Task<Address?> Delete(int id, CancellationToken ct);

}
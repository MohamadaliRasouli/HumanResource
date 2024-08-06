using HumanResource.BusinessLogic.Contract;
using HumanResource.BusinessLogic.DTOs;
using HumanResource.BusinessLogic.DTOs.AddressDto;
using HumanResource.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.BusinessLogic.Services;

public class AddressService(TestDbContext context) : IAddressService
{
    private readonly TestDbContext _context = context;

    public async Task<List<AddressListDto>> List(CancellationToken ct)
    {
        var addresses = await _context.Addresses
            .Select(x => new AddressListDto
            {
          
                PersonId = x.PersonId,
                Address1 = x.Address1,
                PostalCode = x.PostalCode,
                StreetName = x.StreetName ,
               
            }).ToListAsync(ct);

        return addresses;
    }

    public async Task<GetAddressDto> GetAddressByPersonId(int id, CancellationToken ct)
    {
        var address = await _context.Addresses.AsNoTracking()
            .Select(x => new GetAddressDto
            {
                PersonId = x.PersonId,
                Address1 = x.Address1,
                PostalCode = x.PostalCode,
                StreetName = x.StreetName
            }).FirstOrDefaultAsync(p => p.PersonId == id, ct);


        return address;
    }

    public async Task CreateByPersonId(CreateAddressRequestDto address, CancellationToken cs)
    {
        context.Addresses.AddAsync(new Address
        {
            PersonId = address.PersonId,
            Address1 = address.Address1,
            PostalCode = address.PostalCode,
            StreetName = address.StreetName
        }, cs);

        await context.SaveChangesAsync(cs);
    }

    public async Task<Address> UpdateByPersonId(int id ,UpdateAddressRequestDto requestDto, CancellationToken cs)
    {

        var address = _context.Addresses.SingleOrDefault(A => A.AddressId == id);

        address.Address1 = requestDto.Address1;
        address.StreetName = requestDto.StreetName;
        address.PostalCode = requestDto.PostalCode;
 

        context.Update(address);


        return address;


    }

    public async Task<Address?> Delete(int id, CancellationToken ct)
    {
        var address = await context.Addresses.AsTracking().FirstOrDefaultAsync(p => p.PersonId == id, ct);

        if (address == null)
        {
            return null;
        }

        context.Addresses.Remove(address);
        await context.SaveChangesAsync(ct);

        return address;
        
    }
}
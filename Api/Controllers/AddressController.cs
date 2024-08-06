using HumanResource.Api.Models.address;
using HumanResource.BusinessLogic.Contract;
using HumanResource.BusinessLogic.DTOs.AddressDto;
using HumanResource.Data.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Api.Controllers;

[ApiController]
[Route("api/address")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var address = await _addressService.List(ct);

        return Ok(address);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetByPersonId(int id, CancellationToken cs)
    {
        var address = await _addressService.GetAddressByPersonId(id, cs);

        return Ok(address);
    }


    [HttpPost]
    public async Task Create(CreateAddressModel requestDto, CancellationToken cs)
    {
        await _addressService.CreateByPersonId(new CreateAddressRequestDto
        {
            PersonId = requestDto.PersonId,
            Address1 = requestDto.Address1,
            PostalCode = requestDto.PostalCode,
            StreetName = requestDto.StreetName
        }, cs);
    }


    [HttpPut]
    public async Task Update(int id, UpdateAddressModel requestmodel, CancellationToken cs)
    {
        var addresModel = _addressService.UpdateByPersonId(id, new UpdateAddressRequestDto
        {
            Address1 = requestmodel.Address1,
            PostalCode = requestmodel.PostalCode,
            StreetName = requestmodel.StreetName
        }, cs);
    }


    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var person = await _addressService.Delete(id, ct);
        if (person == null)
        {
            return NotFound();
        }

        return Ok();
    }
}
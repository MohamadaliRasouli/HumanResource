using HumanResource.Api.Models.person;
using HumanResource.BusinessLogic.Contract;
using HumanResource.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Api.Controllers;

[Authorize]
[Route("api/person")]
[ApiController]
public class PersonController(IPersonService personRep) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var persons = await personRep.List(ct);
        return Ok(persons);
    }

    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var person = await personRep.GetPersonById(id, ct);
        return Ok(person);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] CreatePersonModel model, CancellationToken ct)
    {
        await personRep.Create(new CreatePersonRequestDto
        {
            Name = model.Name,
            LastName = model.LastName,
            NationalIdentity = model.NationalIdentity,
            BirthDate = model.BirthDate,
            Photo = model.Photo
        }, ct);
        
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, UpdatePersonModel model, CancellationToken ct)
    {
        var existperson = await personRep.Update(id, new UpdatePersonRequestDto
        {
            Name = model.Name,
            LastName = model.LastName,
            NationalIdentity = model.NationalIdentity,
            BirthDate = model.BirthDate,
            Photo = model.Photo
        }, ct);
        if (existperson == null)
        {
            return NotFound();
        }

        return Ok(id);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var person = await personRep.Delete(id, ct);
        if (person == null)
        {
            return NotFound();
        }

        return Ok();
    }
}
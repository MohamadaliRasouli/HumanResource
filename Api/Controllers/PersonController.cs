using HumanResource.Api.Models.Person;
using HumanResource.BusinessLogic.Contract;
using HumanResource.BusinessLogic.DTOs;
using HumanResource.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Api.Controllers;

[Route("api/person")]
[ApiController]
public class PersonController(IPersonService personRep) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var persons =await personRep.List(ct);
        return Ok(persons);
    }
 
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetById(int id,CancellationToken ct)
    {
        var person =await personRep.GetPersonById(id,ct);
        return Ok(person);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreatePersonModel model,CancellationToken ct)
    {
        await personRep.Create(new CreatePersonRequest
        {
            Name = model.Name,
            LastName = model.LastName,
            NationalIdentity = model.NationalIdentity,
            BirthDate = model.BirthDate
        },ct);
        return Ok("Ba movafaghiat post anjam shod");
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, UpdatePersonRequest Model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existperson =await personRep.Update(id, Model,ct);

        if (existperson == null)
        {
            return NotFound();
        }

        return Ok(id);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id,CancellationToken ct)
    {
        var person =await personRep.Delete(id,ct);
        if (person == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
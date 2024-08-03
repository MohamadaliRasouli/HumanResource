using API.BussinesLogic;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/person")]
[ApiController]
public class PersonController(IPersonRepository personRep) : ControllerBase
{
    [HttpGet("list")]
    public IActionResult GetAll()
    {
        var persons = personRep.GetAll();
        return Ok(persons);
    }

    [HttpGet("get/{id:int}")]
    public IActionResult GetById(int id)
    {
        var person = personRep.GetPersonById(id);
        return Ok(person);
    }

    [HttpPost("create")]
    public IActionResult Create(Person person)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        personRep.Create(person);
        return Ok("Ba movafaghiat post anjam shod");
    }

    [HttpPut]
    public IActionResult Update(int id, Person person)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existperson = personRep.Update(id, person);

        if (existperson == null)
        {
            return NotFound();
        }

        return Ok(id);
    }


    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        var person = personRep.Delete(id);
        if (person == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
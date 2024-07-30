using API.BussinesLibrary;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Data;

namespace API.Controllers;

[Route("api/person")]
[ApiController]


public class PersonController : ControllerBase
{
    private readonly IPersonRepository _PersonRep;
    public PersonController(IPersonRepository person)
    {
        _PersonRep = person;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var persons =  _PersonRep.GetAll();
        return Ok(persons);

    }
    
     [HttpGet]
     [Route("{id}")]
    public IActionResult GetById(int id)
     {
    
         var person =  _PersonRep.GetPersonById(id);
         return Ok(person);
    
    
     }
    
    [HttpPost]
     public IActionResult Create(Person person)
     {
    
         _PersonRep.Create(person);
        return Ok();
    
     }
    
     [HttpPut]
     public  IActionResult Update(int id , Person person)
     {
    
         var existperson =  _PersonRep.Update(id , person);
    
         if (existperson == null)
         {
             return NotFound();
         }
    
         return Ok(id);
     }
    
     
     
     
     
     
     
    
     [HttpDelete]
     [Route("{id}")]
     public  IActionResult Delete(int id)
     {
         var person = _PersonRep.Delete(id);
         if (person == null)
         {
    
            return NotFound();
    
       }
    
         return NoContent();
    
     }
    
    
    
    
     
     
     
     
    
    
}
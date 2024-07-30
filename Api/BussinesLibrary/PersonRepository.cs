using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.BussinesLibrary;

public class PersonRepository : IPersonRepository
{

    private readonly ApplicationDbContext _Context;

    public PersonRepository(ApplicationDbContext context)
    {

        _Context = context;

    }


    public  List<Person> GetAll()
    {
        var persons =   _Context.Persons.AsQueryable();

        return persons.ToList();


    }

    public List<Person> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Person GetPersonById(int id)
    {
        var person =  _Context.Persons.FirstOrDefault(p => p.PersonId == id);

        return person;

    }

    public void Create(Person person)
    {
         _Context.Persons.Add(person);
         _Context.SaveChanges();
    }

    public  Person Update(int id , Person person)
    {
        var existedperson =  _Context.Persons.Find(id);

        if (existedperson == null)
        {
            return null;

        }

        existedperson.Name = person.Name;
        existedperson.LastName = person.LastName;
        existedperson.BirthDate = person.BirthDate;
        existedperson.NationalIdentity = person.NationalIdentity;
        _Context.Update(existedperson);
        _Context.SaveChanges();
        
        return person;

    }

    public  Person Delete(int id)
    {

        var person =  _Context.Persons.FirstOrDefault(p => p.PersonId == id);

        if (person == null)
        {
            return null;

        }

        _Context.Persons.Remove(person);
         _Context.SaveChanges();

        return person;

    }
    
    
    
    
}
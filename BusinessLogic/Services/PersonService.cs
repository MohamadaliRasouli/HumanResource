using API.Data;
using BusinessLogic.DTOs;

namespace API.BussinesLogic;

public class PersonService(ApplicationDbContext context) : IPersonService
{
    public List<Person> GetAll()
    {
        var persons = context.Persons.AsQueryable();

        return persons.ToList();
    }

    public List<Person> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Person GetPersonById(int id)
    {
        var person = context.Persons.FirstOrDefault(p => p.PersonId == id);

        return person;
    }

    public void Create(CreatePersonRequest request)
    {
        context.Persons.Add(new Person
        {
            Name = request.Name,
            LastName = request.LastName,
            NationalIdentity = request.NationalIdentity,
            BirthDate = request.BirthDate,
        });
        context.SaveChanges();
    }

    public Person Update(int id, Person person)
    {
        var existedperson = context.Persons.Find(id);

        if (existedperson == null)
        {
            return null;
        }

        existedperson.Name = person.Name;
        existedperson.LastName = person.LastName;
        existedperson.BirthDate = person.BirthDate;
        existedperson.NationalIdentity = person.NationalIdentity;
        context.Update(existedperson);
        context.SaveChanges();

        return person;
    }

    public Person Delete(int id)
    {
        var person = context.Persons.FirstOrDefault(p => p.PersonId == id);

        if (person == null)
        {
            return null;
        }

        context.Persons.Remove(person);
        context.SaveChanges();

        return person;
    }
}
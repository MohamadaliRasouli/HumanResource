using HumanResource.BusinessLogic.Contract;
using HumanResource.BusinessLogic.DTOs;
using HumanResource.Data.Context;
using HumanResource.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.BusinessLogic.Services;

public class PersonService(ApplicationDbContext context) : IPersonService
{
    public async Task<List<PersonListDto>> List(CancellationToken ct)
    {
        var persons = await context.Persons
            .AsTracking()
            .Select(x => new PersonListDto
            {
                Id = x.PersonId,
                Name = x.Name,
                LastName = x.LastName,
                NationalIdentity = x.NationalIdentity,
                BirthDate = x.BirthDate
            })
            .ToListAsync(ct);

        return persons;
    }

    public async Task<GetPersonDto?> GetPersonById(int id, CancellationToken ct)
    {
        var person = await context.Persons
            .AsTracking()
            .Select(x => new GetPersonDto
            {
                Id = x.PersonId,
                Name = x.Name,
                LastName = x.LastName,
                 NationalIdentity = x.NationalIdentity,
                BirthDate = x.BirthDate
            })
            .FirstOrDefaultAsync(p => p.Id == id, ct);

        return person;
    }

    public async Task Create(CreatePersonRequest request, CancellationToken ct)
    {
        await context.Persons.AddAsync(new Person
        {
            Name = request.Name,
            LastName = request.LastName,
            NationalIdentity = request.NationalIdentity,
            BirthDate = request.BirthDate,
        });
        context.SaveChanges();
    }

    public async Task<Person> Update(int id, UpdatePersonRequest request, CancellationToken ct)
    {
        var person = await context.Persons.FindAsync(id , ct);

     

         context.Persons.Update(new Person 
        {
         Name = request.Name,
         LastName = request.LastName,
         NationalIdentity = request.NationalIdentity ,
         BirthDate = request.BirthDate
         
        });

        await  context.SaveChangesAsync();
            
            

        return person;
    }

    public async Task<Person> Delete(int id, CancellationToken ct)
    {
        var person = await context.Persons.FirstOrDefaultAsync(p => p.PersonId == id , ct);

        if (person == null)
        {
            return null;
        }

        context.Persons.Remove(person);
        await context.SaveChangesAsync();

        return person;
    }
}
using HumanResource.BusinessLogic.Contract;
using HumanResource.BusinessLogic.DTOs;
using HumanResource.Data.Context;
using HumanResource.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.BusinessLogic.Services;

public class PersonService(TestDbContext context) : IPersonService
{
    public async Task<List<PersonListDto>> List(CancellationToken ct)
    {
        var persons = await context.Persons
            .AsNoTracking()
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
            .AsNoTracking()
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

        byte[] photoData;
        using (var memoryStream = new MemoryStream())
        {
            await request.Photo.CopyToAsync(memoryStream);
            photoData = memoryStream.ToArray();
        }
        
        
        await context.Persons.AddAsync(new Person
        {
            Name = request.Name,
            LastName = request.LastName,
            NationalIdentity = request.NationalIdentity,
            BirthDate = request.BirthDate,
            Photo = photoData
        } , ct);
        await  context.SaveChangesAsync();
    }

    public async Task<Person> Update(int id, UpdatePersonRequest request, CancellationToken ct)
    {
        var person =  context.Persons.AsTracking().SingleOrDefault(p => p.PersonId == id);

        if (person == null)
        {
            return null;
        }
        

         context.Persons.Update(new Person
         {
             PersonId = person.PersonId,
             Name = request.Name,
             LastName = request.LastName,
             NationalIdentity = request.NationalIdentity,
             BirthDate = request.BirthDate,
             Photo = request.Photo
             
             
         });

        await  context.SaveChangesAsync();
            
            

        return person;
    }

    public async Task<Person> Delete(int id, CancellationToken ct)
    {
        var person = await context.Persons.AsTracking().FirstOrDefaultAsync(p => p.PersonId == id , ct);

        if (person == null)
        {
            return null;
        }

        context.Persons.Remove(person);
        await context.SaveChangesAsync();

        return person;
    }
}
using HumanResource.BusinessLogic.Contract;
using HumanResource.BusinessLogic.DTOs;
using HumanResource.Data.Database;
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

    public async Task Create(CreatePersonRequestDto requestDto, CancellationToken ct)
    {

        byte[] photoData;
        using (var memoryStream = new MemoryStream())
        {
            await requestDto.Photo.CopyToAsync(memoryStream);
            photoData = memoryStream.ToArray();
        }
        
        
        await context.Persons.AddAsync(new Person
        {
            Name = requestDto.Name,
            LastName = requestDto.LastName,
            NationalIdentity = requestDto.NationalIdentity,
            BirthDate = requestDto.BirthDate,
            Photo = photoData
        } , ct);
        await  context.SaveChangesAsync(ct);
    }

    public async Task<Person?> Update(int id, UpdatePersonRequestDto requestDto, CancellationToken ct)
    {
        
      
        var person =  context.Persons.SingleOrDefault(p => p.PersonId == id);

        if (person == null)
        {
            return null;
        }
        
        byte[] photoData;
        using (var memoryStream = new MemoryStream())
        {
            await requestDto.Photo.CopyToAsync(memoryStream , ct);
            photoData = memoryStream.ToArray();
        }

        person.Name = requestDto.Name;
        person.LastName = requestDto.LastName;
        person.NationalIdentity = requestDto.NationalIdentity;
        person.BirthDate = requestDto.BirthDate;
        person.Photo = photoData;
        context.Persons.Update(person);
        

        await  context.SaveChangesAsync(ct);



        return person;
    }

    public async Task<Person?> Delete(int id, CancellationToken ct)
    {
        var person = await context.Persons.AsTracking().FirstOrDefaultAsync(p => p.PersonId == id , ct);

        if (person == null)
        {
            return null;
        }

        context.Persons.Remove(person);
        await context.SaveChangesAsync(ct);

        return person;
    }
}
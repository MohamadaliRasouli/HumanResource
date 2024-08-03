using HumanResource.BusinessLogic.DTOs;
using HumanResource.Data.Entities;

namespace HumanResource.BusinessLogic.Contract;

public interface IPersonService
{
    Task<List<PersonListDto>> List(CancellationToken ct);
    Task<GetPersonDto?> GetPersonById(int id, CancellationToken ct);
    Task Create(CreatePersonRequest person, CancellationToken ct);
    Task<Person?> Update(int id, Person person, CancellationToken ct);
    Task<Person?> Delete(int id, CancellationToken ct);
}
using HumanResource.BusinessLogic.DTOs;
using HumanResource.Data.Database;

namespace HumanResource.BusinessLogic.Contract;

public interface IPersonService
{
    Task<List<PersonListDto>> List(CancellationToken ct);
    Task<GetPersonDto?> GetPersonById(int id, CancellationToken ct);
    Task Create(CreatePersonRequestDto person, CancellationToken ct);
    Task<Person?> Update(int id, UpdatePersonRequestDto requestDto, CancellationToken ct);
    Task<Person?> Delete(int id, CancellationToken ct);
}
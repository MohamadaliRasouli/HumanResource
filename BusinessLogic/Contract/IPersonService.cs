using API.Data;
using BusinessLogic.DTOs;

namespace API.BussinesLogic;

public interface IPersonService
{
    List<Person> GetAll();
    Person GetPersonById(int id);

    void Create(CreatePersonRequest person);

    Person Update(int id, Person person);

    Person Delete(int id);
}
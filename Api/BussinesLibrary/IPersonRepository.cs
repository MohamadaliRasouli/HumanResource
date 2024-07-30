using API.Data;

namespace API.BussinesLibrary;

public interface IPersonRepository
{
        
        List<Person> GetAll();
        Person GetPersonById(int id);
        
       void  Create(Person person);
           
         Person Update(int id , Person person);
        
        Person Delete(int id);
        
}
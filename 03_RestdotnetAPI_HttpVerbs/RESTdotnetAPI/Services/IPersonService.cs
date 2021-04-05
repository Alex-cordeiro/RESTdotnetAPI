using RESTdotnetAPI.Model;
using System.Collections.Generic;


namespace RESTdotnetAPI.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
     }
}

using RESTdotnetAPI.Model;
using System.Collections.Generic;


namespace RESTdotnetAPI.Business

{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long id);
     }
}

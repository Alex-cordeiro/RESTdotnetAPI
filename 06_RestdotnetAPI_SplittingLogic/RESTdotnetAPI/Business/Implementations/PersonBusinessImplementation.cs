using RESTdotnetAPI.Model;
using RESTdotnetAPI.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RESTdotnetAPI.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        private MySQLContext _context;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        //Find Methods....
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);

            
        }

        public Person Update(Person person)
        {

            return _repository.Update(person);
        } 
    }
}

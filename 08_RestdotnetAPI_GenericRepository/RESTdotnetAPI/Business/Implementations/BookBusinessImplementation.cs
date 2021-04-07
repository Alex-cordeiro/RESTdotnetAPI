using RESTdotnetAPI.Model;
using RESTdotnetAPI.Model.Context;
using RESTdotnetAPI.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RESTdotnetAPI.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private MySQLContext _context;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        //Find Methods....
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);

            
        }

        public Book Update(Book book)
        {

            return _repository.Update(book);
        } 
    }
}

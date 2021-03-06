using RESTdotnetAPI.Model;
using RESTdotnetAPI.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RESTdotnetAPI.Business.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private List<Book> books;

        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindByID(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Book Update(Book book)
        {
            // if (!Exists(person.Id)) return new Person();
            
           
            if (!Exists(book.Id)) return new Book();

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();

                    
             
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            


            return book;
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }

        
    }
}

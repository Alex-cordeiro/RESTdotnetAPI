using RESTdotnetAPI.Model;
using System.Collections.Generic;


namespace RESTdotnetAPI.Business

{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
        bool Exists(long id);
     }
}

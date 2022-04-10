using RestAspNet.Model;
using System.Collections.Generic;

namespace RestAspNet.Repository.Implementations
{
    public interface IBookRepository
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        public void Delete(long id);

    }
}
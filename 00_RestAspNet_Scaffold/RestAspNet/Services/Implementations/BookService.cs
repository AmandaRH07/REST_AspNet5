using RestAspNet.Model;
using RestAspNet.Repository.Implementations;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindByID(id);
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }
        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}

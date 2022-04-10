using RestAspNet.Model;
using RestAspNet.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNet.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
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

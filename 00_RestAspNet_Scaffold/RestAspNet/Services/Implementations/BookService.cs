using RestAspNet.Data.Converter.Implementacao;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Model;
using RestAspNet.Repository.Implementations;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter _converter;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }
        public List<BookVO > FindAll()
        {
            return _converter.Parse(_bookRepository.FindAll());
        }

        public BookVO  FindById(long id)
        {
            return _converter.Parse(_bookRepository.FindByID(id));
        }

        public BookVO  Create(BookVO  book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _bookRepository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO  Update(BookVO  book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _bookRepository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}

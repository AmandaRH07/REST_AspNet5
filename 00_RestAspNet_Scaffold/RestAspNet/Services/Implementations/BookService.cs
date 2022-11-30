using RestAspNet.Data.Converter.Implementacao;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Hypermedia.Utils;
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

        public PagedSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirection, int size, int page)
        {
            var sort = (!string.IsNullOrEmpty(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var pageSize = (size < 1) ? 10 : size;
            var offset = page > 0 ? (page - 1) * pageSize : 0;

            string query = @"select * from books b where 1 = 1";

            if (!string.IsNullOrEmpty(title))
                query += $" and b.title like '%{title}%'";

            query += $" order by b.title {sort} offset {offset} rows fetch next {pageSize} rows only";

            string countQuery = "select count(*) from books b where 1 = 1";

            if (!string.IsNullOrEmpty(title))
                countQuery += $" and b.title like '%{title}%'";

            var books = _bookRepository.FindWithPagedSearch(query);
            int totalResults = _bookRepository.GetCount(countQuery);

            return new PagedSearchVO<BookVO>
            {
                Page = page,
                List = _converter.Parse(books),
                Size = pageSize,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }
    }
}

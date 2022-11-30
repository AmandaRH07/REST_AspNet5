using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    public interface IBookService
    {
        List<BookVO > FindAll();
        BookVO  FindById(long id);
        BookVO  Create(BookVO  book);
        BookVO  Update(BookVO  book);
        public void Delete(long id);
        PagedSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirection, int size, int page);
    }
}

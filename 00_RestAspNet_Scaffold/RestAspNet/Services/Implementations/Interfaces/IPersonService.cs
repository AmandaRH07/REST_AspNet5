using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    // person = business
    public interface IPersonService
    {
        PersonVO  Create(PersonVO  person);
        PersonVO  FindByID(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO > FindAll();
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int size, int page);
        PersonVO  Update(PersonVO  person);
        PersonVO Disabled(long id);
        void Delete(long id);
    }
}

using RestAspNet.Data.Converter.Value_Object;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    // person = business
    public interface IPersonService
    {
        PersonVO  Create(PersonVO  person);
        PersonVO  FindByID(long id);
        List<PersonVO > FindAll();
        PersonVO  Update(PersonVO  person);
        void Delete(long id);
    }
}

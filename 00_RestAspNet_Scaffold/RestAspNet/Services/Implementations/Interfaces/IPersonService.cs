using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Model;
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
        PersonVO  Update(PersonVO  person);
        PersonVO Disabled(long id);
        void Delete(long id);
    }
}

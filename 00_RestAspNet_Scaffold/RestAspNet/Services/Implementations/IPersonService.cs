using RestAspNet.Model;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(int id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);
    }
}

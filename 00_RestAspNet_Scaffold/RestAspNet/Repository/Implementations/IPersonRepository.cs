using RestAspNet.Model;
using System.Collections.Generic;

namespace RestAspNet.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindByID(int id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);
        bool Exists(int id);
    }
}

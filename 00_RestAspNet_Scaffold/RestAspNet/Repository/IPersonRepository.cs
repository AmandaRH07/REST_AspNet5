using RestAspNet.Model;
using RestAspNet.Repository.Implementations;
using System.Collections.Generic;

namespace RestAspNet.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disabled(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}

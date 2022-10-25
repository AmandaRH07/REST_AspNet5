using RestAspNet.Model;
using RestAspNet.Repository.Implementations;

namespace RestAspNet.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disabled(long id);
    }
}

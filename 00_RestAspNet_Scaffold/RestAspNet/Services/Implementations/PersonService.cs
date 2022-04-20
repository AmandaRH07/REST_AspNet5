using RestAspNet.Model;
using RestAspNet.Repository.Implementations;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _personRepository.FindByID(id);
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }
    }
}

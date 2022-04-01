using RestAspNet.Model;
using RestAspNet.Model.Context;
using RestAspNet.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindByID(int id)
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

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }
    }
}

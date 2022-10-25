using RestAspNet.Data.Converter.Implementacao;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Model;
using RestAspNet.Repository;
using RestAspNet.Repository.Implementations;
using System.Collections.Generic;

namespace RestAspNet.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonConverter _converter;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter(); 
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_personRepository.FindAll());
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_personRepository.FindByID(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _personRepository.Create(personEntity);

            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _personRepository.Update(personEntity);

            return _converter.Parse(personEntity);
        }
        public PersonVO Disabled(long id)
        {
            var personEntity = _personRepository.Disabled(id);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }
    }
}

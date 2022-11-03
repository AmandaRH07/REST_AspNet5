using RestAspNet.Data.Converter.Implementacao;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Hypermedia.Utils;
using RestAspNet.Repository;
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

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int size, int currentPage)
        {
            var sort = (!string.IsNullOrEmpty(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var pageSize = (size < 1) ? 10 : size;
            var offset = currentPage > 0 ? (currentPage - 1) * pageSize : 0;

            string query = @"select * from person p where 1 = 1";

            if (!string.IsNullOrEmpty(name))
                query += $" and p.first_name like '%{name}%'";

            query += $" order by p.first_name {sort} offset {offset} rows fetch next {pageSize} rows only";

            string countQuery = "select count(*) from person p where 1 = 1";

            if(!string.IsNullOrEmpty(name))
                countQuery += $" and p.first_name like '%{name}%'";

            var persons = _personRepository.FindWithPagedSearch(query);
            int totalResults = _personRepository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = currentPage,
                List = _converter.Parse(persons),
                Size = pageSize,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_personRepository.FindByID(id));
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_personRepository.FindByName(firstName, lastName));
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

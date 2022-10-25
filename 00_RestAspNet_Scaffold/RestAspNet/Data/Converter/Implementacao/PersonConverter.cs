using RestAspNet.Data.Converter.Contrato;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet.Data.Converter.Implementacao
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO> 
    { 
        public Person Parse(PersonVO origem)
        {
            if (origem == null) return null;
                return new Person
                {
                    Id = origem.Id,
                    First_Name = origem.First_Name,
                    Last_Name = origem.Last_Name,
                    Address = origem.Address,
                    Gender = origem.Gender,
                    Enabled = origem.Enabled
                };
        }

        public PersonVO Parse(Person origem)
        {
            if (origem == null) return null;
                return new PersonVO
                {
                    Id = origem.Id,
                    First_Name = origem.First_Name,
                    Last_Name = origem.Last_Name,
                    Address = origem.Address,
                    Gender = origem.Gender,
                    Enabled = origem.Enabled
                };
        }

        public List<Person> Parse(List<PersonVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}

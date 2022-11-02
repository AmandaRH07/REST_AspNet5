using Microsoft.AspNetCore.Http.Features;
using RestAspNet.Model;
using RestAspNet.Model.Context;
using RestAspNet.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(SqlServerContext context) : base(context) { }

        public Person Disabled(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }

            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            var validFirstName = string.IsNullOrEmpty(firstName);
            var validLastName = string.IsNullOrEmpty(lastName);

            if (!validFirstName && !validLastName)
                return _context.Persons.Where(x => x.First_Name.Contains(firstName) && x.Last_Name.Contains(lastName)).ToList(); 

            else if (!validFirstName && validLastName)
                return _context.Persons.Where(x => x.First_Name.Contains(firstName)).ToList();

            else if (validFirstName && !validLastName)
                return _context.Persons.Where(x => x.Last_Name.Contains(lastName)).ToList();

            return null;
        }
    }
}

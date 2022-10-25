using RestAspNet.Model;
using RestAspNet.Model.Context;
using RestAspNet.Repository.Generic;
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
    }
}

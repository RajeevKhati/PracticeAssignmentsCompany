using Company.Project.Core.Data.DataAccess;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Project.EventDomain.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private EventDomainDbContext _context;
        public PersonRepository(EventDomainDbContext context) : base(context)
        {
            _context = context;
        }

        public string GetEmailId(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            return user.Email;
        }


    }
}

using Company.Project.Core.Domain.Repository;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        string GetEmailId(string userId);
    }
}

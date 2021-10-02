using Company.Project.Core.Domain.Repository;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        void EditEvent(Event oldEvent, Event newEvent);
    }
}

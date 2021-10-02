using Company.Project.Core.Domain.Repository;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Project.EventDomain.Repository
{
    public interface IEventAndPersonRepository : IRepository<EventAndPerson>
    {
        public IQueryable<Event> GetEventsAPersonIsInvitedTo(string custId);

        public int GetCountOfInvitedPeople(int eventId);

        void CreateEventAndPersonRow(ICollection<string> userIdsList, int eventId);
    }
}

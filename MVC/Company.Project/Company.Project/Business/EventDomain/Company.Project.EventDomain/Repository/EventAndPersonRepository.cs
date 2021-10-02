using Company.Project.Core.Data.DataAccess;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Project.EventDomain.Repository
{
    public class EventAndPersonRepository : Repository<EventAndPerson>, IEventAndPersonRepository
    {
        private EventDomainDbContext _context;
        public EventAndPersonRepository(EventDomainDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Event> GetEventsAPersonIsInvitedTo(string custId)
        {
            var listOfEventIds = _context.EventsAndPeople.Where(p => p.PersonID.Equals(custId)).Select(p => p.EventID);

            List<Event> eventsAPersonIsInvitedTo = new List<Event>();

            foreach(var eventId in listOfEventIds)
            {
                eventsAPersonIsInvitedTo.Add(_context.Events.Find(eventId));
            }

            return eventsAPersonIsInvitedTo.AsQueryable<Event>();
        }

        public int GetCountOfInvitedPeople(int eventId)
        {
            var countOfInvitedPeople = _context.EventsAndPeople.Where(p => p.EventID == eventId).Count();
            return countOfInvitedPeople;
        }

        public void CreateEventAndPersonRow(ICollection<string> userIdsList, int eventId)
        {
            List<EventAndPerson> list = new List<EventAndPerson>();
            foreach(string userId in userIdsList)
            {
                list.Add(new EventAndPerson { EventID = eventId, PersonID = userId });
            }
            _context.EventsAndPeople.AddRange(list);
            _context.SaveChanges();
        }
        
    }
}

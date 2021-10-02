using Company.Project.Core.Data.DataAccess;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.Repository
{

    public class EventRepository : Repository<Event>, IEventRepository
    {
        private EventDomainDbContext _context;
        public EventRepository(EventDomainDbContext context) : base(context)
        {
            _context = context;
        }

        public void EditEvent(Event oldEvent, Event newEvent)
        {
            //var changeEvent = _context.Events.Attach(editThisEvent);
            //changeEvent.State = EntityState.Modified;
            _context.Entry<Event>(oldEvent).CurrentValues.SetValues(newEvent);
        }
    }

    
}

using Company.Project.EventDomain.AppServices;
using Company.Project.EventFacade.FacadeLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventFacade.FacadeFactory
{
    public class EventFacadeFactory : IEventFacadeFactory
    {
        private IEventAppService _eventAppService;
        public EventFacadeFactory(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }

        public IEventFacade Create()
        {
            return new EventFacade(_eventAppService);
        }
    }
}

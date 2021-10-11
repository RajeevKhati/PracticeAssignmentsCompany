using Company.Project.EventDomain.AppServices;
using Company.Project.EventFacade.FacadeLayer;
using Company.Project.EventFacade.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventFacade.FacadeFactory
{
    public class EventFacadeFactory : IEventFacadeFactory
    {
        private IEventAppService _eventAppService;
        private readonly ICommentNotificationSubject commentNotification;

        public EventFacadeFactory(IEventAppService eventAppService, ICommentNotificationSubject commentNotification)
        {
            _eventAppService = eventAppService;
            this.commentNotification = commentNotification;
        }

        public IEventFacade Create()
        {
            return new EventFacade(_eventAppService, commentNotification);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Project.EventFacade;
using Company.Project.EventDomain.AppServices.DTOs;

namespace Company.Project.EventFacade.Subject
{
    public interface ICommentNotificationSubject
    {
        void AddObserver(ICommentNotificationObserver observer);
        void RemoveObserver(ICommentNotificationObserver observer);
        void NotifyObserver(CommentNotificationDTO commentNotificationDTO);
    }
}

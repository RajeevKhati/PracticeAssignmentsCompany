using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.EventFacade.Subject
{
    public class CommentNotificationSubject : ICommentNotificationSubject
    {
        List<ICommentNotificationObserver> observerList;
        public CommentNotificationSubject()
        {
            observerList = new List<ICommentNotificationObserver>();
        }
        public void AddObserver(ICommentNotificationObserver observer)
        {
            observerList.Add(observer);
        }

        public void NotifyObserver(CommentNotificationDTO commentNotificationDTO)
        {
            foreach(var observer in observerList)
            {
                observer.Notify(commentNotificationDTO);
            }
        }

        public void RemoveObserver(ICommentNotificationObserver observer)
        {
            observerList.Remove(observer);
        }
    }
}

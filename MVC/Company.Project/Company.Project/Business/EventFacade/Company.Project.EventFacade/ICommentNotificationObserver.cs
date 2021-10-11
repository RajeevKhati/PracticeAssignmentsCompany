using System;
using System.Collections.Generic;
using System.Text;
using Company.Project.EventDomain.AppServices.DTOs;

namespace Company.Project.EventFacade
{
    public interface ICommentNotificationObserver
    {
        public void Notify(CommentNotificationDTO commentNotificationDTO);
    }
}

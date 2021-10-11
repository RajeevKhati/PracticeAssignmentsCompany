using Company.Project.Core.Data.Transaction;
using Company.Project.EventDomain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.UoW
{
    public interface IEventUnitOfWork:IUnitOfWork
    {
        public IEventRepository Events { get; }
        public IEventAndPersonRepository EventsAndPeople { get; }
        public IAccountRepository Accounts { get; }
        public ICommentRepository Comments { get; }
        public IPersonRepository People { get; }
        public ICommentNotificationRepository CommentNotifications { get; }
    }
}

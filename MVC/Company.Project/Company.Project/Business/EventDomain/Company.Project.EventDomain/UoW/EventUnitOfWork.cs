using Company.Project.Core.Data.Transaction;
using Company.Project.Core.ExceptionManagement;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Repository;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.UoW
{
    public class EventUnitOfWork:UnitOfWork,IEventUnitOfWork
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        public IEventRepository Events { get; private set; }
        public IEventAndPersonRepository EventsAndPeople { get; private set; }
        public IAccountRepository Accounts { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public IPersonRepository People { get; private set; }
        public ICommentNotificationRepository CommentNotifications { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyProjectUnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public EventUnitOfWork(EventDomainDbContext dbContext, IExceptionManager exceptionManager, IServiceProvider serviceProvider)
            : base(dbContext, exceptionManager)
        {
            _serviceProvider = serviceProvider;
            Events = _serviceProvider.GetService<IEventRepository>();
            EventsAndPeople = 
                _serviceProvider.GetService<IEventAndPersonRepository>();
            Accounts = _serviceProvider.GetService<IAccountRepository>();
            Comments = _serviceProvider.GetService<ICommentRepository>();
            People = _serviceProvider.GetService<IPersonRepository>();
            CommentNotifications = _serviceProvider.GetService<ICommentNotificationRepository>();
        }
    }
}

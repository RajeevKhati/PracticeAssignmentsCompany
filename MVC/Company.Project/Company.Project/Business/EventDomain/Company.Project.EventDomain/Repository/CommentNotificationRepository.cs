using Company.Project.Core.Data.DataAccess;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Project.EventDomain.Repository
{
    public class CommentNotificationRepository : Repository<CommentNotification>, ICommentNotificationRepository
    {
        private EventDomainDbContext _context;
        public CommentNotificationRepository(EventDomainDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<CommentNotification> GetNotificationsOfUser(string userId)
        {
            var notificationList = _context.CommentNotifications.Where(c => c.EventOwnerId.Equals(userId));
            return notificationList.ToList<CommentNotification>();
        }
    }

    
}

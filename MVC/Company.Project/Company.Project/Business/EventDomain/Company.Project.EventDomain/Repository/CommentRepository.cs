using Company.Project.Core.Data.DataAccess;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private EventDomainDbContext _context;
        public CommentRepository(EventDomainDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

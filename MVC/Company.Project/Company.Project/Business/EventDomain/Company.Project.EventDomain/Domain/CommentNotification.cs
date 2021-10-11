using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.Domain
{
    public class CommentNotification : DomainBase
    {
        public string EventOwnerId { get; set; }
        public string CommentContent { get; set; }
        public string NameOfPersonWhoCommented { get; set; }
        public int EventId { get; set; }
    }
}

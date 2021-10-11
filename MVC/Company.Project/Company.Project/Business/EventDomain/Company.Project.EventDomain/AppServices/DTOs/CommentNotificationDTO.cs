using System;
using System.Collections.Generic;
using System.Text;
using Company.Project.Core.AppServices;

namespace Company.Project.EventDomain.AppServices.DTOs
{
    public class CommentNotificationDTO : DtoBase
    {
        public string EventOwnerId { get; set; }
        public string CommentContent { get; set; }
        public string NameOfPersonWhoCommented { get; set; }
        public int EventId { get; set; }
    }
}

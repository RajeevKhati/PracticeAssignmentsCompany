using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class CommentNotificationViewModel : Core.WebMVC.ViewModel
    {
        public string EventOwnerId { get; set; }
        public string CommentContent { get; set; }
        public string NameOfPersonWhoCommented { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
    }
}

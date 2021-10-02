using Company.Project.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.AppServices.DTOs
{
    public class CommentDTO : DtoBase
    {
        public string Content { get; set; }

        public int EventID { get; set; }
        public EventDTO Event { get; set; }
    }
}

using Company.Project.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.AppServices.DTOs
{
    public class EventDTO : DtoBase
    {
        public string TitleOfBook { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public TimeSpan StartTime { get; set; }

        public bool Type { get; set; } //true => private, false => public

        public int DurationInHours { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string UserID { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }

        public string InviteByEmail { get; set; }

    }
}

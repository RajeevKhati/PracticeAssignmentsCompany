using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Project.EventDomain.Domain
{
    public class Comment : DomainBase
    {
        [Required()]
        public string Content { get; set; }

        /**
         * use CreatedByUserId from DomainBase instead of this property
         *
        [Required()]
        public int UserId { get; set; }
        */

        [Required()]
        public int EventID { get; set; }

        [ForeignKey("EventID")]
        public Event Event { get; set; }
    }
}

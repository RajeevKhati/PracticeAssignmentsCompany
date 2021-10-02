using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Project.EventDomain.Domain
{
    public class EventAndPerson : DomainBase
    {
        public string PersonID { get; set; }
        public int EventID { get; set; }
    }
}

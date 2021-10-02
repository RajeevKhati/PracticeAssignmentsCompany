using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.Project.ProductDomain.Domain
{
    public class Person : DomainBase
    {

        [Required()]
        public string FullName { get; set; }

        [Required()]
        public string Email { get; set; }

        public virtual ICollection<EventAndPerson> EventsAndPeople { get; set; }
    }
}

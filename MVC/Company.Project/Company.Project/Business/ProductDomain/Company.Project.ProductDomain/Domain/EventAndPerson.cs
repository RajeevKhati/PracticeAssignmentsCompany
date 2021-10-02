using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Project.ProductDomain.Domain
{
    public class EventAndPerson
    {
        public int PersonID { get; set; }
        public int EventID { get; set; }
        [ForeignKey("PersonID")]
        public Person Person { get; set; }
        [ForeignKey("EventID")]
        public Event Event { get; set; }
    }
}

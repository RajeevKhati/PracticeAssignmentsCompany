using Company.Project.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.AppServices.DTOs
{
    public class EventAndPersonDTO : DtoBase
    {
        public string PersonID { get; set; }
        public int EventID { get; set; }
    }
}

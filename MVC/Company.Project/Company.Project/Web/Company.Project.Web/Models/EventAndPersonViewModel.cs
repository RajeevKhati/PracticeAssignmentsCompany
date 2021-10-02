using Company.Project.Core.WebMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class EventAndPersonViewModel : ViewModel
    {
        public string PersonID { get; set; }
        public int EventID { get; set; }
    }
}

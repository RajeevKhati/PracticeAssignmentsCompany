using Company.Project.Core.WebMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class CommentViewModel : ViewModel
    {
        [Required()]
        [DisplayName("Comment")]
        public string Content { get; set; }

        public int EventID { get; set; }

        public EventViewModel Event { get; set; }
    }
}

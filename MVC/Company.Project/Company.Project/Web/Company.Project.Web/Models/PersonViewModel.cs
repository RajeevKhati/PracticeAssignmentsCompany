using Company.Project.Core.WebMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class PersonViewModel : ViewModel
    {
        
        public string FullName { get; set; }

        [Required(ErrorMessage ="Please enter email")]
        [EmailAddress(ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

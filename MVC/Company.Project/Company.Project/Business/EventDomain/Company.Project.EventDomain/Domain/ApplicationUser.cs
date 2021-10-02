using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.Project.EventDomain.Domain
{
    public class ApplicationUser : IdentityUser
    {
        [Required()]
        public string FullName { get; set; }
    }
}

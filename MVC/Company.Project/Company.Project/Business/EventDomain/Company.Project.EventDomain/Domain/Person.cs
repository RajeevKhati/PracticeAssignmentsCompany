using Company.Project.Core.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.Project.EventDomain.Domain
{
    public class Person : DomainBase
    {
        [Required()]
        public string FullName { get; set; }
        [Required()]
        public string Email { get; set; }

        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

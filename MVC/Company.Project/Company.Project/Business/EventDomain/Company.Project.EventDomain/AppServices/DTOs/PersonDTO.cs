﻿using Company.Project.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.AppServices.DTOs
{
    public class PersonDTO : DtoBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

    }
}

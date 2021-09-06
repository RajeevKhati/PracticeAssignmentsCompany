using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise17
{
    class CustomException : ApplicationException
    {
        public override string Message => "Cannot play more than five times";
    }
}

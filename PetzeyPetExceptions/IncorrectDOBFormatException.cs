using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class IncorrectDOBFormatException : ApplicationException
    {
        public IncorrectDOBFormatException() : base(String.Format("Incorrect Date of Birth")) { }
    }
}

// DOB REGEX: "^(3[01]|[12][0-9]|0?[1-9])/(1[0-2]|0?[1-9])/(?:[0-9]{2})?[0-9]{2}$"

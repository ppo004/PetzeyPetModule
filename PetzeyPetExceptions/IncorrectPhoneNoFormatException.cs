using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class IncorrectPhoneNoFormatException : ApplicationException
    {
        public IncorrectPhoneNoFormatException() : base(String.Format("Incorrect Phone Number")) { }
    }
}

// PhoneNo REGEX: "^[0-9]+$"
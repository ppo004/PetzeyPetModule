using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class IncorrectEmailFormatException : ApplicationException
    {
        public IncorrectEmailFormatException() : base(String.Format("Incorrect Email Format")) { }
    }
}

// Email REGEX: "[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+"
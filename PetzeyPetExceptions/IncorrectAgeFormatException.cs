using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class IncorrectAgeFormatException : ApplicationException
    {
        public IncorrectAgeFormatException() : base(String.Format("Incorrect Age Format")) { }
    }
}

//
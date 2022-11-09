using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class IncorrectURLFormatException : ApplicationException
    {
        public IncorrectURLFormatException() : base(String.Format("Incorrect URL")) { }
    }
}

// URL REGEX: "((http|https)://)(www.)?[a-zA-Z0-9@:%._\\+~#?&//=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%._\\+~#?&//=]*)"
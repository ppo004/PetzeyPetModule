using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class IncorrectBloodGroupFormatException : ApplicationException
    {
        public IncorrectBloodGroupFormatException() : base(String.Format("Incorrect Blood Group")) { }
    }
}

//	Regex Expression: /(A|B|AB|O)[+-]/
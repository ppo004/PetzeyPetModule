using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class EmptyFieldException : ApplicationException
    {
        public EmptyFieldException() : base(String.Format("Field Cannot be Empty")) { }
    }
}


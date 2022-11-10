using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class IncorrectLocationFormat : ApplicationException
    {
        public IncorrectLocationFormat() : base(String.Format("Incorrect Location Format")) { }
    }
}

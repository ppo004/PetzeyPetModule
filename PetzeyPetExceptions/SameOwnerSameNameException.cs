using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class SameOwnerSameNameException : ApplicationException
    {
        public SameOwnerSameNameException() : base(String.Format("Two pets of the same owner cannot have same names")) { }
    }
}

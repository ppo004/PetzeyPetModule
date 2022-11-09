using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class OwnerDoesntExistException : ApplicationException
    {
        public OwnerDoesntExistException() : base(String.Format("Pet Owner Doesn't exist")) { }
    }
}

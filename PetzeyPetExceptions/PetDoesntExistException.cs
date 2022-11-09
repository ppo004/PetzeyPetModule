using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class PetDoesntExistException : ApplicationException
    {
        public PetDoesntExistException() : base(String.Format("Pet Doesn't exist")) { }
    }
}

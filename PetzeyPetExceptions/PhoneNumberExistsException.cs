using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class PhoneNumberExistsException:ApplicationException
    {
        public PhoneNumberExistsException() : base(String.Format("Phone Number Exists")) { }
    }
}

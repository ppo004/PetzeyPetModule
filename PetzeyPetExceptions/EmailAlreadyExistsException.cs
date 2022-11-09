using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class EmailAlreadyExistsException:ApplicationException
    {
        public EmailAlreadyExistsException():base(string.Format("Email already exists")) { }
    }
}

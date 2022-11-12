using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class AllergyAlreadyExistsException:ApplicationException
    {
        public AllergyAlreadyExistsException() : base(String.Format("Allergy already exists")) { }
    }
}

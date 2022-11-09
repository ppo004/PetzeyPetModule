using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetExceptions
{
    public class RepeatedAllergyException : ApplicationException
    {
        public RepeatedAllergyException() : base(String.Format("Allergies cannot be Repeated")) { }
    }
}

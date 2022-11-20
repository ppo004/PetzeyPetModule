using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public class BloodGroupValidator : IValidator
    {
        public bool Validate(string value)
        {
            Regex regex = new Regex("(A|B|AB|O)[+-]");
            MatchCollection matchedAuthors = regex.Matches(value);
            return matchedAuthors.Count != 0;
        }
    }
}

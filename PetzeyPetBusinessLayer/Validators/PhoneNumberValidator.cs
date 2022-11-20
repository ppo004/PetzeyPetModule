using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public class PhoneNumberValidator : IValidator
    {
        public bool Validate(string value)
        {
            Regex regex = new Regex("^[789]\\d{9}$");
            MatchCollection matchedAuthors = regex.Matches(value);
            return matchedAuthors.Count != 0;

        }
    }
}

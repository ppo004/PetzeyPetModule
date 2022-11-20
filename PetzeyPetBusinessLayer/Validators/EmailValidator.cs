using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public class EmailValidator : IValidator
    {
        public bool Validate(string value)
        {
            Regex regex = new Regex("[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+");
            MatchCollection matchedAuthors = regex.Matches(value);
            return matchedAuthors.Count != 0;
        }
    }
}

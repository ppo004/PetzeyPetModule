using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public class LocationValidator : IValidator
    {
        public bool Validate(string value)
        {
            Regex regex = new Regex("^https?\\:\\/\\/(www\\.|maps\\.)?google(\\.[a-z]+){1,2}\\/maps\\/?\\?([^&]+&)*(ll=-?[0-9]{1,2}\\.[0-9]+,-?[0-9]{1,2}\\.[0-9]+|q=[^&]+)+($|&)");
            MatchCollection matchedAuthors = regex.Matches(value);
            return matchedAuthors.Count != 0;
        }
    }
}

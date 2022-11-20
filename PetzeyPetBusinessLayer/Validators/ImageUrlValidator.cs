using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public class ImageUrlValidator : IValidator
    {
        public bool Validate(string value)
        {
            Regex regex = new Regex("((http|https)://)(www.)?[a-zA-Z0-9@:%._\\+~#?&//=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%._\\+~#?&//=]*)");
            MatchCollection matchedAuthors = regex.Matches(value);
            return matchedAuthors.Count != 0;
        }
    }
}

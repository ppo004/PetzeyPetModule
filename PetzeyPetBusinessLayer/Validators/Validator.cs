using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public class Validator
    {
        public bool EmailValidator(string email)
        {
            Regex regex = new Regex("[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+");
            MatchCollection matchedAuthors = regex.Matches(email);
            return matchedAuthors.Count != 0;
        }
        public bool PhoneNumberValidator(string phoneNumber)
        {
            Regex regex = new Regex("^[0-9]+$");
            MatchCollection matchedAuthors = regex.Matches(phoneNumber);
            return matchedAuthors.Count != 0;
        }
        public bool ImageUrlValidator(string imageUrl)
        {
            Regex regex = new Regex("((http|https)://)(www.)?[a-zA-Z0-9@:%._\\+~#?&//=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%._\\+~#?&//=]*)");
            MatchCollection matchedAuthors = regex.Matches(imageUrl);
            return matchedAuthors.Count != 0;
        }
    }
    }


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
            Regex regex = new Regex("^[789]\\d{9}$");
            MatchCollection matchedAuthors = regex.Matches(phoneNumber);
            return matchedAuthors.Count != 0;
        }
        public bool ImageUrlValidator(string imageUrl)
        {
            Regex regex = new Regex("((http|https)://)(www.)?[a-zA-Z0-9@:%._\\+~#?&//=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%._\\+~#?&//=]*)");
            MatchCollection matchedAuthors = regex.Matches(imageUrl);
            return matchedAuthors.Count != 0;
        }
        public bool BloodGroupValidator(string bloodGroup)
        {
            Regex regex = new Regex("/(A|B|AB|O)[+-]/");
            MatchCollection matchedAuthors = regex.Matches(bloodGroup);
            return matchedAuthors.Count != 0;
        }
        public bool DOBValidator(string dob)
        {
            Regex regex = new Regex("^(3[01]|[12][0-9]|0?[1-9])/(1[0-2]|0?[1-9])/(?:[0-9]{2})?[0-9]{2}$");
            MatchCollection matchedAuthors = regex.Matches(dob);
            return matchedAuthors.Count != 0;
        }
        public bool LocationValidator(string locationURL)
        {
            Regex regex = new Regex("/^https?\\:\\/\\/(www\\.|maps\\.)?google(\\.[a-z]+){1,2}\\/maps\\/?\\?([^&]+&)*(ll=-?[0-9]{1,2}\\.[0-9]+,-?[0-9]{1,2}\\.[0-9]+|q=[^&]+)+($|&)/");
            MatchCollection matchedAuthors = regex.Matches(locationURL);
            return matchedAuthors.Count != 0;
        }
    }
}



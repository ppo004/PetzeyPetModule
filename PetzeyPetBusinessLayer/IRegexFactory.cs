using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    internal interface IRegexFactory
    {
        bool ValidateEmail(string email);
        bool ValidatePhoneNumber(string phoneNumber);
        bool ValidateImageUrl(string imageUrl);
    }
}

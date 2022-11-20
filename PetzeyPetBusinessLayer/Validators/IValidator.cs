using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public interface IValidator
    {
        Boolean Validate(string value);
    }
}

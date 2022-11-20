using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer.Validators
{
    public class ValidatorFactory
    {
        private static ValidatorFactory instance;
        public Dictionary<string,IValidator> Validator;
        private ValidatorFactory() {
            Validator = new Dictionary<string,IValidator>();
            Validator["email"] = new EmailValidator();
            Validator["location"] = new LocationValidator();
            Validator["bloodgroup"] = new BloodGroupValidator();
            Validator["image"] = new ImageUrlValidator();
            Validator["phone"] = new PhoneNumberValidator();
        }
        public static ValidatorFactory GetInstance()
        {
            if (instance == null) instance = new ValidatorFactory();
            return instance;
        }
    }
}

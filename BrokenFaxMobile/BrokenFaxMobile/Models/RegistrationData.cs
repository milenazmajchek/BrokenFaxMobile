using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenFaxMobile.Models
{
    public class RegistrationData
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string RepeatedPassword { get; set; }

        public string Name { get; set; }
    }
}

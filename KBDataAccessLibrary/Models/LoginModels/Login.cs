using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models.LoginModels
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Student Student { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class LogIn
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
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
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
    }
}
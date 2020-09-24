using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class UserRatio
    {
        public int Admin { get; set; }
        public int Tourist { get; set; }
        public int Guide { get; set; }
    }
}
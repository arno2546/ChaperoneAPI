using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class Search
    {
        public string SearchString { get; set; }
        public bool Culture { get; set; }
        public bool NightLife { get; set; }
        public bool Sports { get; set; }
        public bool Food { get; set; }
        public bool Festival { get; set; }
    }
}
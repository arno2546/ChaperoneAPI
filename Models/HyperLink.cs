﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class HyperLink
    {
        public string HRef { get; set; }
        public string HttpMethod { get; set; }
        public string Relation { get; set; }
    }
}
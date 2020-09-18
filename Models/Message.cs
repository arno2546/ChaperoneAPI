using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
        public string MessageString { get; set; }
    }
}
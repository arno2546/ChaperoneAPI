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
        public int CommentId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string MessageString { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }
        public int TouristId { get; set; }
        public int Location { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
        public User User { get; set; }
    }
}
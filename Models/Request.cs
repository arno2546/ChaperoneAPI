using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        [Column(TypeName = "varchar"), StringLength(300), Display(Name = "Location")]
        [Required(ErrorMessage = "Location cannot be empty")]
        public string Location { get; set; }
        public int TouristId { get; set; }
        public int GuideId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestState { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
        public IEnumerable<User> Users { get; set; }
    }
}
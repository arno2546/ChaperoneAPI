using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Column(TypeName = "varchar"), StringLength(300), Display(Name = "Review String")]
        public string ReviewString { get; set; }
        public int ReviewerId { get; set; }
        public int ReviewedId { get; set; }
        public int Rating { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
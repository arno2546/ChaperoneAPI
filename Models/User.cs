using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar"), StringLength(300), Display(Name = "Email")]
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }

        [Column(TypeName = "varchar"), StringLength(300), Display(Name = "Name")]
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Column(TypeName = "varchar"), StringLength(30), Display(Name = "Password")]
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Contact")]
        [Required(ErrorMessage = "Contact cannot be empty")]
        public string Contact { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "User Type")]
        [Required(ErrorMessage = "User Type cannot be empty")]
        public string UserType { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Status")]
        [Required(ErrorMessage = "Status cannot be empty")]
        public string Status { get; set; }

        [Column(TypeName = "varchar"), StringLength(300), Display(Name = "Gender")]
        public string Gender { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Language(s)")]
        public string Language { get; set; }

        [Column(TypeName = "varchar"), StringLength(300), Display(Name = "Location")]        
        public string Location { get; set; }

        [Column(TypeName = "varchar"), StringLength(300), Display(Name = "Bio")]         
        public string Bio { get; set; }

        [Display(Name = "Culture")]
        public bool Culture { get; set; }

        [Display(Name = "Night Life")]
        public bool NightLife { get; set; }

        [Display(Name = "Sports")]
        public bool Sports { get; set; }

        [Display(Name = "Food")]
        public bool Food { get; set; }

        [Display(Name = "Festival")]
        public bool Festival { get; set; }
        public int Rate { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
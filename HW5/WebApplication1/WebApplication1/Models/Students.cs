using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Students
    {
        [Required]
        public int VNumber { get; set; }
        [Required]
        [Display (Name = "First Nmae:")]
        public string firstN { get; set; }
        [Required]
        [Display (Name = "Last Name")]
        public string LastN { get; set; }
        [Required]
        [Display(Name = "Date Name")]
        public string Date { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Major")]
        public string Major { get; set; }
        [Required]
        [Display(Name = "Minor")]
        public string Minor { get; set; }
        [Required]
        [Display(Name = "Advisor")]
        public string Advisor { get; set; }
    }
}
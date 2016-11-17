using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    /// <summary>
    /// Model class with data annotation when add to database only all data type pass the validation
    /// </summary>
    public class Student
    {
        [Required][Key][Display(Name = "ID")]
        public int ID { get; set; }
        [Required][Display(Name = "VNumber")]
        public string VNumber { get; set; }
        [Required]
        [Display (Name = "First Name:")]
        public string FirstName { get; set; }
        [Required]
        [Display (Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date")]
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
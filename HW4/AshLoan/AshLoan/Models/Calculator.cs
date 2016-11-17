using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//this is imported for validation each domain model property
namespace AshLoan.Models
{
    public class Calculator
    {
        /// <summary>
        /// validation helper method will help to validate the user input: 
        /// 1: if it is empty, since input text boxes are required
        /// 2: if the type of the input does not match the object property's type since the view is strongly typed, 
        /// when the view was created the modle was binded to the view. 
        /// </summary>
        [Required(ErrorMessage = "Please enter loan amount")]
        public double pr { get; set; }
        [Required(ErrorMessage = "Please enter interest rate")]
        public  double rate { get; set; }
        [Required(ErrorMessage = "Please enter term in months")]
        public int term { get; set; }

        public double payment { get; set; }
        public double total { get; set; }   
    }
}
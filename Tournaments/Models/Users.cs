using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tournaments.Models
{
    public class Users
    {

        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]

        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last name")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "Tournament name cannot be longer than 50 characters")]

        public string Username { get; set; }



        [Required(ErrorMessage = "Please enter email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "Password  cannot be longer than 50 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]

        public string ConfirmPassword { get; set; }

        
        

       

    }
}
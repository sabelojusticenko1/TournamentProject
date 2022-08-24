using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tournaments.Models
{
    public class Role
    {
        [Key]

        public int RoleID { get; set; }

        [Required(ErrorMessage = "Please select user role")]
        [StringLength(50)]
        [Display(Name = "User Role")]
        public string RoleName { get; set; }

    }
}
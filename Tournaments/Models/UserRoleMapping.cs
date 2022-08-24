using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tournaments.Models
{
    public class UserRoleMapping
    {
        [Key]
        public string UserRoleMappingID { get; set; }

        public int UserID { get; set; }

        public virtual Users FK_UserID { get; set; }

        public int RoleID { get; set; }

        public virtual UserRole FK_RoleID { get; set; }
    }
}
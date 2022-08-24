using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournaments.Models
{
    public class Tournament
    {
        [Key]

        public Int64 TournamentID { get; set; }

        
        [Required(ErrorMessage = "Please enter tournament name")]
        [Display(Name = "Tournament name")]
        [StringLength(200, ErrorMessage = "Tournament name cannot be longer than 200 characters")]
        //[MaxLength(200)]

        public string TournamentName {get; set;}

        public virtual ICollection<Event> Events { get; set; }

    }
}
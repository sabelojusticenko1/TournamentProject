using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournaments.Models
{
    public class EventDetailStatus
    {
        [Key]

        public Int16 EventDetailStatusID { get; set; }

        
        [Display(Name = "Event Detail status")]
        [StringLength(50, ErrorMessage = "Tournament name cannot be longer than 50 characters")]
        //[MaxLength(50)]
        public string EventDetailStatusName { get; set; }

        public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournaments.Models
{
    public class Event
    {
        [Key]

        public Int64 EventID { get; set; }

        //[ForeignKey("Tournament")]
        public Int64 TournamentID { get; set; }

        public virtual Tournament FK_TournamentID { get; set; }

        [Required]
        [Display(Name = "Event name")]
        [StringLength(100, ErrorMessage = "Tournament name cannot be longer than 100 characters")]
        //[MaxLength(100)]
        public string EventName { get; set; }

        [Display(Name = "Event number")]
        public Int16? EventNumber { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Event Date & Time")]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? EventDateTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Event End Date & Time")]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? EventEndDateTime { get; set; }

        public bool? AutoClose { get; set; }

        public virtual ICollection<EventDetail> EventDetail { get; set; }







    }
}
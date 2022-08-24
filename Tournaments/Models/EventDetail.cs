using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournaments.Models
{
    public class EventDetail
    {
        [Key]

        public Int64 EventDetailID { get; set; }

        //[ForeignKey("Event")]

        public Int64 EventID { get; set; }

        public virtual Event FK_EventID { get; set; }

        //[ForeignKey("EventDetailStatus")]

        public Int16 EventDetailStatusID { get; set; }

        public virtual EventDetailStatus FK_EventDetailStatusID { get; set; }

        [Required]
        [Display(Name = "Event detail name")]
        [StringLength(50, ErrorMessage = "Event name cannot be longer than 50 characters")]
        //[MaxLength(50)]
        public string EventDetailName { get; set; }

        [Display(Name = "Event detail number")]
        //[Column(TypeName = "decimal(18,7)")]
        public Int16? EventDetailNumber { get; set; }

        [Display(Name = "Event odd")]
        public decimal? EventDetailOdd { get; set; }

        [Display(Name = "Finishing position")]
        public Int16? FinishingPosition { get; set; }

        [Display(Name = "First timer")]
        public bool? FirstTimer { get; set; }

        

    }
}
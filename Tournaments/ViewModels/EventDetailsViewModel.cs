using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.ViewModels
{
    public class EventDetailsViewModel
    {
        public Tournament Tournament { get; set; }
        public IEnumerable<Event> Event { get; set; }

       

        //public IEnumerable<EventDetail> EventDetails { get; set; }
        //public Event EventName { get; set; }

        //public Event EventNumber { get; set; }

        //public Event EventDateTime { get; set; }

        //public Event EventEndDateTime { get; set; }

        //public Event AutoClose { get; set; }

        ////EventDetails
        //public Int64 EventDetailID { get; set; }

        ////[ForeignKey("Event")]

        //public Int64 EventID { get; set; }

        //public virtual Event FK_EventID { get; set; }

        ////[ForeignKey("EventDetailStatus")]

        //public Int16 EventDetailStatusID { get; set; }

        //public virtual EventDetailStatus FK_EventDetailStatusID { get; set; }

   
        //public string EventDetailName { get; set; }


        
        //public Int16 EventDetailNumber { get; set; }

        //public decimal EventDetailOdd { get; set; }

        //public Int16 FinishingPosition { get; set; }

        //public bool FirstTimer { get; set; }
    }
}
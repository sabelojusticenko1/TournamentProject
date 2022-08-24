using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.ViewModels
{
    public class EventEventDetailsViewModel
    {
        public Event Event { get; set; }

        public IEnumerable<EventDetail> EventDetail { get; set; }

        public IEnumerable<EventDetailStatus> EventDetailStatus { get; set; }


    }
}
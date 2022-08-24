using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.ViewModels
{
    public class EventDetailCreateViewModel
    {
        public Event Event { get; set; }

        public EventDetail EventDetail { get; set; }

        public IEnumerable<EventDetailStatus> EventDetailStatus { get; set; }
    }
}
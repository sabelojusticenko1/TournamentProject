using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.ViewModels
{
    public class EventTourIDViewModel
    {
        public Tournament Tournament { get; set; }
        public Event Event { get; set; }
    }
}
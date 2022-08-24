using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.DAL
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        private AppDbContext DbContext;
        public EventRepository(AppDbContext _DbContext)
           : base(_DbContext)
        {
            DbContext = _DbContext;

        }
        public override Event GetById(int eventID)
        {
            return DbContext.Event.Find(eventID);
        }
    }
}
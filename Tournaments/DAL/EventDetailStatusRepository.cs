using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.DAL
{
    public class EventDetailStatusRepository : RepositoryBase<EventDetailStatus>, IEventDetailStatusRepository
    {
        private AppDbContext DbContext;
        public EventDetailStatusRepository(AppDbContext _DbContext)
           : base(_DbContext)
        {
            DbContext = _DbContext;

        }
        public override EventDetailStatus GetById(int eventID)
        {
            return DbContext.EventDetailStatus.Find(eventID);
        }
    }
}
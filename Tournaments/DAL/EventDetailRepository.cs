using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.DAL
{
    public class EventDetailRepository : RepositoryBase<EventDetail>, IEventDetailRepository
    {

        private AppDbContext DbContext;
        public EventDetailRepository(AppDbContext _DbContext)
           : base(_DbContext)
        {
            DbContext = _DbContext;

        }
        public override EventDetail GetById(int eventID)
        {
            return DbContext.EventDetail.Find(eventID);
        }
    }
}
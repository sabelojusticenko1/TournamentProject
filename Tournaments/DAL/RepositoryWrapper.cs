using Tournaments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournaments.DAL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _appDbContext;
        private ITournamentRepository tournament;
        private IEventRepository _event;
        private IEventDetailRepository _eventDetail;
        private IEventDetailStatusRepository _eventDetailStatus;
        private IUserRepository _user;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ITournamentRepository Tournament
        {
            get
            {
                if (tournament == null)
                {
                    tournament = new TournamentRepository(_appDbContext);
                }
                return tournament;
            }
        }

        public IEventRepository Event
        {
            get
            {
                if(_event == null)
                {
                    _event = new EventRepository(_appDbContext);
                }
                return _event;

            }
        }

        public IEventDetailRepository EventDetail
        {
            get
            {
                if (_eventDetail == null)
                {
                    _eventDetail = new EventDetailRepository(_appDbContext);
                }
                return _eventDetail;

            }
        }

        public IEventDetailStatusRepository EventDetailStatus
        {
            get
            {
                if (_eventDetailStatus == null)
                {
                    _eventDetailStatus = new EventDetailStatusRepository(_appDbContext);
                }
                return _eventDetailStatus;

            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_appDbContext);
                }
                return _user;

            }
        }



        //public IEventDetailsRepository EventDetails => throw new NotImplementedException();



        //public void Save()
        //{
        //    _appDbContext.SaveChanges();
        //}
    }
}

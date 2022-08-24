using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournaments.DAL
{
    public interface IRepositoryWrapper
    {
        ITournamentRepository Tournament { get; }

        IEventRepository Event { get; }

        IEventDetailRepository EventDetail { get; }

        //void Save();
    }
}

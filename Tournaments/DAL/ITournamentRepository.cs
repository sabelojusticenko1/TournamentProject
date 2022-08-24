using Tournaments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournaments.DAL
{
    public interface ITournamentRepository : IRepositoryBase<Tournament>
    {
        //Tournament GetById(int id);
    }
}

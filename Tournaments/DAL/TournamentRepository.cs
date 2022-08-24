using Tournaments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournaments.DAL
{
    public class TournamentRepository : RepositoryBase<Tournament>, ITournamentRepository
    {
        private AppDbContext DbContext;
        public TournamentRepository(AppDbContext _DbContext)
           : base(_DbContext)
        {
            DbContext = _DbContext;

        }
        public override Tournament GetById(int tournamentID)
        {
            return DbContext.Tournament.Find(tournamentID);
        }
    }
}

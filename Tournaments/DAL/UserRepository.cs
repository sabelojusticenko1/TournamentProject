using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;
using Tournaments.ViewModels;

namespace Tournaments.DAL
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        private AppDbContext DbContext;
        public UserRepository(AppDbContext _DbContext)
           : base(_DbContext)
        {
            DbContext = _DbContext;

        }

        public bool UserExist(Users _user)
        {
            
           return appDbContext.Set<Users>().Any(p => p.Username == _user.Username && p.Password == _user.Password);
        }

        public Users FirstDefault(Users _user)
        {
            return appDbContext.Set<Users>().FirstOrDefault(p => p.Username == _user.Username && p.Password == _user.Password);

        }
    }
}
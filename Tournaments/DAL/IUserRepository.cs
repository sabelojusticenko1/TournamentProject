using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;
using Tournaments.ViewModels;

namespace Tournaments.DAL
{
    public interface IUserRepository : IRepositoryBase<Users>
    {
        bool UserExist(Users _user);

        Users FirstDefault(Users _user);
    }
}

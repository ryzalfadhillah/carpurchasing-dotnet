using carpurchasing_DAL.Models;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class UserService : IUserService
    {
        readonly CarfurchasingfinalContext _dbcontext;

        public UserService(CarfurchasingfinalContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<VwMstUser> GetUsers()
        {
            return _dbcontext.VwMstUsers.ToList();
        }
    }
}

using carpurchasing_DAL.Models;
using carpurchasing_DAL.Repositories.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class AuthService : IAuthService
    {
        readonly CarfurchasingfinalContext _dbContext;

        public AuthService(CarfurchasingfinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CheckLogin(string username)
        {
            try
            {
                bool isExist = _dbContext.MstUsers.Any(x => x.Username == username);
                if (isExist)
                {
                    return username;
                }
                else
                {
                    throw new Exception($"username tidak ditemukan");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"data login salah : {ex.Message}");
            }
        }
    }
}

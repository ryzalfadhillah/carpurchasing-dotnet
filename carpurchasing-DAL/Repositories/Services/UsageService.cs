using carpurchasing_DAL.Models;
using carpurchasing_DAL.Repositories.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class UsageService: IUsageService
    {
        readonly CarfurchasingfinalContext _dbcontext;

        public UsageService(CarfurchasingfinalContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<MstUsage> GetUsage()
        {
            return _dbcontext.MstUsages.ToList();
        }
    }
}

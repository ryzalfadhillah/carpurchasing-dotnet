using carpurchasing_DAL.Models;
using carpurchasing_DAL.Repositories.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class SaleService: ISaleService
    {
        readonly CarfurchasingfinalContext _dbcontext;

        public SaleService(CarfurchasingfinalContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<VwMstSale> GetSales()
        {
            return _dbcontext.VwMstSales.ToList();
        }
    }
}

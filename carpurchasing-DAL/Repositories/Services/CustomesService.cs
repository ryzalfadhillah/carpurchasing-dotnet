using carpurchasing_DAL.Models;
using carpurchasing_DAL.Models.Dto.Res;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class CustomesService : ICustomerService
    {
        readonly CarfurchasingfinalContext _context;

        public CustomesService(CarfurchasingfinalContext context)
        {
            _context = context;
        }

        public List<MstCustomer> GetCustomers()
        {
            return _context.MstCustomers.ToList();
        }
    }
}

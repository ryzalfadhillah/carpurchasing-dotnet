using carpurchasing_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services.Interface
{
    public interface ICustomerService
    {
        List<MstCustomer> GetCustomers();
    }
}

using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace carpurchasing.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var dataCust = _customerService.GetCustomers();
            return View(dataCust);
        }
    }
}

using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace carpurchasing.Controllers
{
    public class UsageController : Controller
    {
        private readonly IUsageService _usageService;

        public UsageController(IUsageService usageService)
        {
            _usageService = usageService;
        }

        public IActionResult Index()
        {
            var dataUsage = _usageService.GetUsage();
            return View(dataUsage);
        }
    }
}

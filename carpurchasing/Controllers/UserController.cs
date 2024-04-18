using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace carpurchasing.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var dataUser = _service.GetUsers();
            return View(dataUser);
        }
    }
}

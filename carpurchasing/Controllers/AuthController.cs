using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using carpurchasing_DAL.Repositories.Services.Interface;
using carpurchasing_DAL.Models.Dto.Req;

namespace carpurchasing.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(ReqLoginDto user)
        {
            try
            {
                var response = _authService.CheckLogin(user.Username);
                if (response != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Username", user.Username),
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "username or password is incorrect";
                    ViewBag.Status = "error";
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                ViewBag.Message = ex.Message;
                ViewBag.Status = "error";
                return View("Login");
            }
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Message = "logout success";
            ViewBag.Status = "success";
            return View("Login");
        }
    }
}

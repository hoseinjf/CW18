using AppDomainAppService.CW18.Users;
using AppDomainCore.CW18.Users.Contract.AppServices;
using AppDomainCore.CW18.Users.Entities;
using Microsoft.AspNetCore.Mvc;
using Quiz2.Entity;

namespace MVC.Endpoint.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userServise = new UserAppService();


        [HttpGet]
        public IActionResult LoginGet(string username, string password)
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var log = _userServise.Login(username, password);
            if (log != null)
            {
                Online.user = new User()
                {
                    Username = username,
                    Password = password
                };
                return RedirectToAction("index", "RootUser");
            }
            else
            {
                return RedirectToAction("RegisterGet", "User");
            }
        }


        [HttpGet]
        public IActionResult RegisterGet(string firstName, string lastName, string username, string password)
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User user)
        {
            
            var reg = _userServise.Register(user);
            if (reg != null)
            {
                return RedirectToAction("LoginGet", "User");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }
    }
}

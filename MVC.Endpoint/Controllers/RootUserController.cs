
using AppDomainAppService.CW18.Users;
using AppDomainCore.CW18.Cards.Entities;
using AppDomainCore.CW18.Users.Contract.AppServices;
using AppDomainCore.CW18.Users.Entities;
using Microsoft.AspNetCore.Mvc;
using Quiz2.Entity;

namespace MVC.Endpoint.Controllers
{
    public class RootUserController : Controller
    {

        public static Card card { get; set; }

        IUserAppService userAppService = new UserAppService();
        public IActionResult index(string username, string password)
        {
            if (Online.user != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");
        }
    }
}

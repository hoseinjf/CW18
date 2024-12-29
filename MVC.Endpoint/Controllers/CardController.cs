using Microsoft.AspNetCore.Mvc;

namespace MVC.Endpoint.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

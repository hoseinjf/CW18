using Microsoft.AspNetCore.Mvc;

namespace MVC.Endpoint.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

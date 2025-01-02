using AppDomainAppService.CW18.Transactions;
using AppDomainCore.CW18.Transactions.Contract.AppServices;
using Microsoft.AspNetCore.Mvc;
using Quiz2.Entity;

namespace MVC.Endpoint.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionAppService _transactionAppService = new TransactionAppService();

        public IActionResult Index()
        {
            if (Online.user != null)
            {
                if (Online.card != null)
                {
                    var list = _transactionAppService.GetTransactions(Online.card.CardNumber);
                    return View(list);
                }
            }
            return RedirectToAction("index", "Home");

        }
    }
}

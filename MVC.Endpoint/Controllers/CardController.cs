using AppDomainAppService.CW18.Cards;
using AppDomainCore.CW18.Cards.Contract.AppServices;
using AppDomainCore.CW18.Cards.Entities;
using AppDomainCore.CW18.Users.Entities;
using Microsoft.AspNetCore.Mvc;
using Quiz2.Entity;

namespace MVC.Endpoint.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardAppService _appService = new CardAppService();
        
        [HttpGet]       
        public IActionResult index()
        {
            if (Online.user != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public IActionResult index(string username, string cardNumber, string password)
        {
            if (Online.user != null)
            {
                var log = _appService.Login(Online.user.Username, cardNumber, password);
                if (log != null)
                {
                    Online.card = new Card()
                    {
                        Id = log.Id,
                        CardNumber = log.CardNumber,
                        Password = log.Password
                    };
                    return RedirectToAction("index", "RootUser");
                }
                else
                {
                    return RedirectToAction("RegisterCard", "Card");
                }
            }
            return RedirectToAction("index", "Home");
        }


        [HttpGet]
        public IActionResult RegisterCard()
        {
            if (Online.user != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");
        }


        [HttpPost]
        public IActionResult RegisterCard(Card card)
        {
            if (Online.user != null)
            {
                Card card2 = new Card()
                {
                    CardNumber = card.CardNumber,
                    Balance = card.Balance,
                    Password = card.Password,
                    UserId = Online.user.Id,
                };
                var c = _appService.Add(card2);
                if (c != null)
                {
                    return RedirectToAction("index", "Card");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }
            }
            return RedirectToAction("index", "Home");
        }


    }
}

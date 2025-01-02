using AppDomainAppService.CW18.Cards;
using AppDomainAppService.CW18.Transactions;
using AppDomainCore.CW18.Cards.Contract.AppServices;
using AppDomainCore.CW18.Cards.Entities;
using AppDomainCore.CW18.Transactions.Contract.AppServices;
using AppDomainCore.CW18.Transactions.Entities;
using AppDomainCore.CW18.Users.Entities;
using Microsoft.AspNetCore.Mvc;
using Quiz2.Entity;

namespace MVC.Endpoint.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardAppService _appService = new CardAppService();
        private readonly ITransactionAppService _transactionAppService = new TransactionAppService();

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


        [HttpGet]
        public IActionResult ChengPassword()
        {
            if (Online.user != null)
            {
                if (Online.card != null)
                {
                    return View();
                }
            }
            return RedirectToAction("index", "Home");
        }


        [HttpPost]
        public IActionResult ChengPassword(string oldPass, string newPass)
        {
            if (Online.user != null)
            {
                if (Online.card != null)
                {
                    var pass = _appService.ChengPassword(Online.user.Username, oldPass, newPass);
                    if (pass == true)
                    {
                        return RedirectToAction("index", "Card");
                    }
                    else
                    {
                        return RedirectToAction("ChengPassword", "Card");
                    }
                }
            }
            return RedirectToAction("index", "Home");
        }


        [HttpGet]
        public IActionResult Balans(string cardNumber)
        {
            if (Online.user != null)
            {
                if (Online.card != null)
                {
                    var caed = Online.card;
                    cardNumber = caed.CardNumber;
                    var bal = _appService.ShowCardBalans(cardNumber);
                    caed.Balance = bal;
                    return View(caed);
                }
            }
            return RedirectToAction("index", "Home");
        }


        [HttpGet]
        public IActionResult CardToCard(string destinationCard)
        {
            Transaction transaction = new Transaction();
            transaction.DestinationCard = Online.card;
            var Ocard2 = transaction.DestinationCard;
            transaction.DestinationCard.User = Online.user;
            var Ouser2 = transaction.DestinationCard.User;

            Ocard2.User = Ouser2;
            Ouser2.Cards.Add(Ocard2);
            if (Ouser2 != null)
            {
                if (Ocard2 != null)
                {
                    var send = _appService.GetCardByCardNumber(destinationCard);
                    if (send != null)
                    {
                        ViewData["FirstName"] = send.User.FirstName;
                        ViewData["LastName"] = send.User.LastName;
                    }

                    _appService.SendCode(Online.card.CardNumber);
                    return View(transaction);
                }
            }
            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public IActionResult CardToCard(string sourceCard, string destinationCard,float Amount,string check)
        {
            if (Online.user != null)
            {
                if (Online.card != null)
                {
                    var send = _appService.GetCardByCardNumber(destinationCard);



                    if (send != null)
                    {
                        ViewData["FirstName"] = send.User.FirstName;
                        ViewData["LastName"] = send.User.LastName;

                        return RedirectToAction("CardToCard", new { destinationCard = destinationCard });
                    }



                    if (_appService.CheckCode(check, Online.card.CardNumber) == true)
                    {
                        var Transfer = _transactionAppService.Transfer(Online.card.CardNumber, destinationCard, Amount);
                        if (Transfer == true)
                        {
                            return RedirectToAction("Index", "Transaction");
                        }
                        else
                        {
                            return RedirectToAction("index", "Home");
                        }
                    }
                    else
                    {
                        return RedirectToAction("index", "Home");
                    }
                }
            }
            return RedirectToAction("index", "Home");
        }



    }
}

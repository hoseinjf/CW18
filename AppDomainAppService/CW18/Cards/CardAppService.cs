using App.Infra.Data.Repos.Ef.CW18.Cards;
using AppDomainCore.CW18.Cards.Contract.AppServices;
using AppDomainCore.CW18.Cards.Contract.Services;
using AppDomainCore.CW18.Cards.Entities;
using AppDomainService.CW18.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainAppService.CW18.Cards
{
    public class CardAppService : ICardAppService
    {
        private readonly ICardService cardService;
        public CardAppService()
        {
            cardService = new CardService();
        }
        public Card Add(Card card)
        {
            return cardService.Add(card);
        }
        public Card GetCardByCardNumber(string code)
        {
            return cardService.GetCardByCardNumber(code);
        }
        public float SetTax(float Amount)
        {
            return cardService.SetTax(Amount);
        }
        public float ShowCardBalans(string cardNumber)
        {
            return cardService.ShowCardBalans(cardNumber);
        }
        public bool ChengPassword(string username, string oldPassword, string newPassword)
        {
            return cardService.ChengPassword(username, oldPassword, newPassword);
        }
        public Card Login(string username, string cardNumber, string password)
        {
            var login = cardService.Login(username, cardNumber, password);
            if (login != null)
            {

                return login;
            }
            else
            {

                return null;
            }
        }
        public void SendCode(string cardNumber)
        {
            cardService.SendCode(cardNumber);
        }
        public bool CheckCode(string input, string cardNumber)
        {
            return cardService.CheckCode(input, cardNumber);
        }
    }
}

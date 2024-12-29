using App.Infra.Data.Repos.Ef.CW18.Cards;
using AppDomainCore.CW18.Cards.Contract.Services;
using AppDomainCore.CW18.Cards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainService.CW18.Cards
{
    public class CardService :ICardService
    {
        private readonly CardRepository cardRepository;
        public CardService()
        {
            cardRepository = new CardRepository();
        }

        public Card Add(Card card)
        {
            return cardRepository.Add(card);
        }
        public Card GetCardByCardNumber(string code)
        {
            return cardRepository.GetCardByCardNumber(code);
        }
        public float SetTax(float Amount)
        {
            return cardRepository.SetTax(Amount);
        }
        public float ShowCardBalans(string cardNumber)
        {
            return cardRepository.ShowCardBalans(cardNumber);
        }
        public bool ChengPassword(string username, string oldPassword, string newPassword)
        {
            return cardRepository.ChengPassword(username, oldPassword, newPassword);
        }
        public Card Login(string username, string cardNumber, string password)
        {
            var login = cardRepository.Login(username, cardNumber, password);

                return login;
        }
        public void SendCode(string cardNumber)
        {
            cardRepository.SendCode(cardNumber);
        }
        public bool CheckCode(string input, string cardNumber)
        {
            return cardRepository.CheckCode(input, cardNumber);
        }

    }
}

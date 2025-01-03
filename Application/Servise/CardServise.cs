﻿using Quiz2.Entity;
using Quiz2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Servise
{
    public class CardServise
    {
        private readonly CardRepository cardRepository;
        public CardServise()
        {
            cardRepository = new CardRepository();
        }

        public Card Add(Card card)
        {
            return cardRepository.Add(card);
        }
        public Card Get(string code)
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
        public Card Login(string username,string cardNumber, string password)
        {
            var login = cardRepository.Login(username, cardNumber, password);
            if (login != null)
            {
                Console.WriteLine("welcom");
                return login;
            }
            else
            {
                Console.WriteLine("card number or password is not true");
                return null;
            }
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

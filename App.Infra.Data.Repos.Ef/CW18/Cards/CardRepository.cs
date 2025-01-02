using App.Infra.Data.Repos.Ef.CW18.Db;
using AppDomainCore.CW18.Cards.Contract.Repositories;
using AppDomainCore.CW18.Cards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CW18.Cards
{
    public class CardRepository : ICardRepository
    {
        string file = "C:\\Users\\MOHO\\source\\repos\\Quiz2\\Quiz2\\File\\randCode.txt";

        private readonly AppDbContext appDbContext;
        public CardRepository()
        {
            appDbContext = new AppDbContext();
        }

        public Card Add(Card card)
        {
            Card card2 = new Card()
            {

                CardNumber = card.CardNumber,
                Balance = card.Balance,
                Password = card.Password,
                UserId = card.UserId
            };
            appDbContext.Cards.Add(card2);
            appDbContext.SaveChanges();
            return card2;
        }
        public bool ChengPassword(string username, string oldPassword, string newPassword)
        {
            var card = appDbContext.Cards
                .FirstOrDefault(x => x.Password == oldPassword
                && x.User.Username == username);
            if (card != null)
            {
                card.Password = newPassword;
                appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Card GetCardByCardNumber(string cardNumber)
        {
            var card = appDbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
            var user = appDbContext.Users.FirstOrDefault(x => x.Id == card.UserId);
            card.User = user;
            return card;
        }

        public float SetTax(float Amount)
        {
            float tax = 0f;
            if (Amount != 0f)
            {
                if (Amount > 1000)
                {
                    tax = Amount * 1.5f / 100;
                    return Amount -= tax;
                }
                else if (Amount <= 1000)
                {
                    tax = Amount * 0.5f / 100;
                    return Amount -= tax;
                }
            }
            return 0f;
        }

        public float ShowCardBalans(string cardNumber)
        {
            var card = appDbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
            //appDbContext.Entry(card).Reload();
            if (card != null)
            {
                return card.Balance;
            }
            return 0f;
        }
        public Card Login(string username, string cardNumber, string password)
        {
            var ac = appDbContext.Cards.FirstOrDefault
                (x => x.CardNumber == cardNumber
                && x.Password == password && x.User.Username == username);
            if (ac != null)
            {
                return ac;
            }
            return null;
        }
        public void SendCode(string cardNumber)
        {
            try
            {
                var ac = appDbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
                ac.CodeDate = DateTime.Now.AddMinutes(5);
                appDbContext.SaveChanges();

                Random random = new Random();
                var number = random.Next(10000, 99999);
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(number);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
        }
        public bool CheckCode(string input, string cardNumber)
        {
            var ac = appDbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
            if (ac.CodeDate >= DateTime.Now)
            {
                if (File.ReadAllText(file).Contains(input))
                {
                    return true;
                }
            }
            return false;
        }

    }
}

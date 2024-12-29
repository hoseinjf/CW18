using AppDomainCore.CW18.Cards.Entities;

namespace AppDomainCore.CW18.Cards.Contract.AppServices
{
    public interface ICardAppService
    {
        public Card GetCardByCardNumber(string cardNumber);
        public bool ChengPassword(string username, string oldPassword, string newPassword);
        public float ShowCardBalans(string cardNumber);
        public float SetTax(float Amount);
        public Card Login(string username, string cardNumber, string password);
        public void SendCode(string cardNumber);
        public Card Add(Card card);
        public bool CheckCode(string input, string cardNumber);
    }
}

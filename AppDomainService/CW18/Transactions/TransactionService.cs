
using App.Infra.Data.Repos.Ef.CW18.Transactions;
using AppDomainCore.CW18.Cards.Contract.Services;
using AppDomainCore.CW18.Transactions.Contract.Repositories;
using AppDomainCore.CW18.Transactions.Contract.Services;
using AppDomainCore.CW18.Transactions.Entities;
using AppDomainService.CW18.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainService.CW18.Transactions
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardService cardServise;
        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
            cardServise = new CardService();
        }
        public bool Transfer(string sourceCard, string destinationCard, float transferAmount)
        {
            var soursCardId = cardServise.GetCardByCardNumber(sourceCard).Id;
            var destinationCardId = cardServise.GetCardByCardNumber(destinationCard).Id;
            var dCard = cardServise.GetCardByCardNumber(destinationCard);
            transferAmount = cardServise.SetTax(transferAmount);
            if (_transactionRepository.Transfer(soursCardId, destinationCardId, transferAmount) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Transaction> GetTransactions(string sourceCard)
        {
            var ac2 = cardServise.GetCardByCardNumber(sourceCard);
            var ac = _transactionRepository.GetTransactions(ac2.Id);

            foreach (var item in ac)
            {
               string res = $"Source Card Number: {item.SourceCard.CardNumber} -- " +
                    $"Destination Card Number: {item.DestinationCard.CardNumber} -- " +
                    $"Transaction Date: {item.TransactionDate} -- " +
                    $"Amount: {item.Amount} -- " +
                    $"Successful: {item.isSuccessful}";
            }
            return ac;
        }
    }
}

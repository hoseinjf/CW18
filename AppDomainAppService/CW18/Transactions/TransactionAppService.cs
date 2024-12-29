using App.Infra.Data.Repos.Ef.CW18.Transactions;
using AppDomainCore.CW18.Cards.Contract.Services;
using AppDomainCore.CW18.Transactions.Contract.AppServices;
using AppDomainCore.CW18.Transactions.Contract.Repositories;
using AppDomainCore.CW18.Transactions.Contract.Services;
using AppDomainCore.CW18.Transactions.Entities;
using AppDomainService.CW18.Cards;
using AppDomainService.CW18.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainAppService.CW18.Transactions
{
    public class TransactionAppService : ITransactionAppService
    {

        private readonly ITransactionService transactionService;
        private readonly ICardService cardServise;
        public TransactionAppService()
        {
            transactionService = new TransactionService();
            cardServise = new CardService();
        }
        public bool Transfer(string sourceCard, string destinationCard, float transferAmount)
        {
            if (transactionService.Transfer(sourceCard, destinationCard, transferAmount) == true)
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
            var ac = transactionService.GetTransactions(sourceCard);
            return ac;
        }
    }
}

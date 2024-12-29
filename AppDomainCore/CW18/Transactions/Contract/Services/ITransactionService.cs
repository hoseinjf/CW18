using AppDomainCore.CW18.Transactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.CW18.Transactions.Contract.Services
{
    public interface ITransactionService
    {
        public bool Transfer(string sourceCard, string destinationCard, float transferAmount);

        public List<Transaction> GetTransactions(string sourceCard);
    }
}

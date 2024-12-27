using App.Domain.Core.Golestan.Student.DTOs;
using AppDomainCore.CW18.Transactions.Entities;

namespace App.Domain.Core.Golestan.Student.Data.Repositories
{
    public interface ITransactionRepository
    {
        public bool Transfer(int sourceCard, int destinationCard, float transferAmount);

        public List<Transaction> GetTransactions(int sourceCard);
    }
}

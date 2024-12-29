using AppDomainCore.CW18.Transactions.Entities;

namespace AppDomainCore.CW18.Transactions.Contract.Repositories
{
    public interface ITransactionRepository
    {
        public bool Transfer(int sourceCard, int destinationCard, float transferAmount);

        public List<Transaction> GetTransactions(int sourceCard);
    }
}

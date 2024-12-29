using AppDomainCore.CW18.Transactions.Entities;

namespace AppDomainCore.CW18.Transactions.Contract.AppServices
{
    public interface ITransactionAppService
    {
        public bool Transfer(string sourceCard, string destinationCard, float transferAmount);

        public List<Transaction> GetTransactions(string sourceCard);
    }
}

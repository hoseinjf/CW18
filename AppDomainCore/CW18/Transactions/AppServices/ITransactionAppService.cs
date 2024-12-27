using App.Domain.Core.Golestan.Student.DTOs;

namespace App.Domain.Core.Golestan.Student.AppServices
{
    public interface ITransactionAppService
    {
        List<TransactionDto> GetTransactions();
    }
}

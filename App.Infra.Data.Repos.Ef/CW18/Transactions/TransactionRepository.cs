using App.Infra.Data.Repos.Ef.CW18.Db;
using AppDomainCore.CW18.Transactions.Contract.Repositories;
using AppDomainCore.CW18.Transactions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CW18.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext appDbContext;
        public TransactionRepository()
        {
            appDbContext = new AppDbContext();
        }
        public bool Transfer(int sourceCardId, int destinationCardId, float transferAmount)
        {

            var userAc = appDbContext.Cards.FirstOrDefault(x => x.Id == sourceCardId);
            var destinationAc = appDbContext.Cards.FirstOrDefault(y => y.Id == destinationCardId);
            if (userAc != null && destinationAc != null)
            {
                if (transferAmount > 0)
                {
                    if (userAc.Balance > transferAmount)
                    {
                        if (userAc.CardNumber != destinationAc.CardNumber)
                        {
                            userAc.Balance -= transferAmount;
                            destinationAc.Balance += transferAmount;

                            Transaction transaction = new Transaction()
                            {
                                SourceCardId = sourceCardId,
                                SourceCard = userAc,
                                DestinationCard = destinationAc,
                                DestinationCardId = destinationCardId,
                                Amount = transferAmount,
                                isSuccessful = true,
                                TransactionDate = DateTime.UtcNow
                            };
                            appDbContext.Transactions.Add(transaction);
                            appDbContext.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Transaction> GetTransactions(int Id)
        {
            var ac = appDbContext.Transactions.Where(x => x.SourceCardId == Id
            || x.DestinationCardId == Id)
                .Select
                (z => new Transaction
                {
                    Amount = z.Amount,
                    DestinationCard = z.DestinationCard,
                    isSuccessful = z.isSuccessful,
                    SourceCard = z.SourceCard,
                    TransactionDate = z.TransactionDate
                }
                ).ToList();
            if (ac != null)
            {
                return ac;
            }
            return new List<Transaction>();
        }

    }
}

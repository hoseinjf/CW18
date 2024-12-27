﻿using App.Domain.Core.Golestan.Student.AppServices;
using App.Domain.Core.Golestan.Student.Data.Repositories;
using App.Domain.Core.Golestan.Student.DTOs;
using AppDomainAppService.CW18.Cards;
using AppDomainCore.CW18.Transactions.Entities;
using AppDomainCore.CW18.Transactions.Services;
using Quiz2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainAppService.CW18.Transactions
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly CardService cardServise;
        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
            cardServise = new CardService();
        }
        public bool Transfer(string sourceCard, string destinationCard, float transferAmount)
        {
            var soursCardId = cardServise.Get(sourceCard).Id;
            //var sCard = cardServise.Get(sourceCard);
            var destinationCardId = cardServise.Get(destinationCard).Id;
            var dCard = cardServise.Get(destinationCard);
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
            var ac2 = cardServise.Get(sourceCard);
            var ac = _transactionRepository.GetTransactions(ac2.Id);

            foreach (var item in ac)
            {
                Console.WriteLine($"Source Card Number: {item.SourceCard.CardNumber} -- " +
                    $"Destination Card Number: {item.DestinationCard.CardNumber} -- " +
                    $"Transaction Date: {item.TransactionDate} -- " +
                    $"Amount: {item.Amount} -- " +
                    $"Successful: {item.isSuccessful}");
                Console.WriteLine("-------------------------------------------------------");
            }
            return ac;
        }
    }
}
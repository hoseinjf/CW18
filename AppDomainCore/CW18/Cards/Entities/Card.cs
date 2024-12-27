using AppDomainCore.CW18.Transactions.Entities;
using Quiz2.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.CW18.Cards.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [MinLength(16)]
        [MaxLength(16)]
        public string CardNumber { get; set; }
        public string? HolderName { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public int WrongPasswordTries { get; set; } = 0;
        public DateTime? CodeDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Transaction> TransactionsAsSource { get; set; } = new List<Transaction>();
        public List<Transaction> TransactionsAsDestination { get; set; } = new List<Transaction>();
    }
}

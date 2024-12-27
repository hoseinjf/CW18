using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public Card SourceCard { get; set; }
        public int SourceCardId { get; set; }
        public Card DestinationCard { get; set; }
        public int DestinationCardId { get; set; }
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool isSuccessful { get; set; }=false;

    }
}

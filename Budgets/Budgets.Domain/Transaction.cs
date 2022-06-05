using NodaMoney;
using System;

namespace Budgets.Domain
{
    public class Transaction
    {
        protected Transaction() { }

        public Money Money { get; set; }
        public DateTime Date { get; set; }

        public Transaction(Money money, DateTime date)
        {
            Money = money;
            Date = date;
        }
    }
}
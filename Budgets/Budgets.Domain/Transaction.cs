using NodaMoney;
using System;

namespace Budgets.Domain
{
    public class Transaction
    {
        protected Transaction() { }

        public int Id { get; }
        public Money Money { get; }
        public DateTime Date { get; }
        public Payee Payee { get; }
        public Category Category { get; }
        public Account Account { get; }

        public Transaction(int id, Money money, DateTime date, Payee payee, Category category, Account account)
        {
            Id = id;
            Money = money;
            Date = date;
            Payee = payee;
            Category = category;
            Account = account;

            Account.AddTransactions(this);
            Category.AssociateTransaction(this);
        }
    }
}
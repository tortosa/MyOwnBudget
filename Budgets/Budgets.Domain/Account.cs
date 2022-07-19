using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class Account
    {
        protected Account() { }

        public int Id { get; }
        public string Label { get; }
        public List<Transaction> Transactions { get; }
        public Money Balance => GetBalance();

        private Money GetBalance()
        {
            return Transactions.Sum(transaction => transaction.Money.Amount);
        }

        public Account(int id, string label)
        {
            Transactions = new List<Transaction>();

            if (string.IsNullOrEmpty(label))
                label = "Default account label";
            Label = label;
            Id = id;
        }

        public void AddTransactions(params Transaction[] transactions)
        {
            Transactions.AddRange(transactions);
        }
    }
}
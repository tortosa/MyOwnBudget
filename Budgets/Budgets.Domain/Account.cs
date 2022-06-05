using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class Account
    {
        protected Account() { }

        public string Label { get; set; }
        public List<Transaction> Transactions { get; }

        public Money Balance => GetBalance();

        private Money GetBalance()
        {
            return Transactions.Sum(transaction => (decimal)transaction.Money);
        }

        public Account(string label)
        {
            Transactions = new List<Transaction>();

            if (string.IsNullOrEmpty(label))
                label = "Default account label";
            Label = label;
        }

        public void AddTransactions(params Transaction[] transactions)
        {
            Transactions.AddRange(transactions);
        }
    }
}
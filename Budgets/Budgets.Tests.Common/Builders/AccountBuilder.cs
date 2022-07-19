using System.Collections.Generic;
using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class AccountBuilder
    {
        public int Id { get; private set; }
        public string Label { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public AccountBuilder()
        {
            Label = "defaultLabel";
            Transactions = new List<Transaction>();
        }

        public AccountBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public AccountBuilder WithLabel(string label)
        {
            this.Label = label;
            return this;
        }

        public AccountBuilder WithTransactions(params Transaction[] transactions)
        {
            this.Transactions.AddRange(transactions);
            return this;
        }

        public Account Build()
        {
            var account = new Account(Id, Label);
            account.AddTransactions(Transactions.ToArray());
            return account;
        }
    }
}
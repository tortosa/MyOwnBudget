using System.Collections.Generic;

namespace Budgets.Domain.UnitTests.Builders
{
    public class AccountBuilder
    {
        private string label;
        private List<Transaction> transactions;

        public AccountBuilder()
        {
            label = "defaultLabel";
            transactions = new List<Transaction>();
        }

        public AccountBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public AccountBuilder WithTransactions(params Transaction[] transactions)
        {
            this.transactions.AddRange(transactions);
            return this;
        }

        public Account Build()
        {
            var account = new Account(label);
            account.AddTransactions(transactions.ToArray());
            return account;
        }
    }
}
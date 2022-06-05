using NodaMoney;
using System;

namespace Budgets.Domain.UnitTests.Builders
{
    public class TransactionBuilder
    {
        private Money money;
        private DateTime date;

        public TransactionBuilder()
        {
            money = 0;
            date = new DateTime(2022, 6, 5);
        }

        public TransactionBuilder WithMoney(Money money)
        {
            this.money = money;
            return this;
        }

        public TransactionBuilder WithDate(DateTime date)
        {
            this.date = date;
            return this;
        }

        public Transaction Build()
        {
            var transaction = new Transaction(money, date);
            return transaction;
        }
    }
}
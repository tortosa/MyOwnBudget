using System;

namespace Budgets.Domain.UnitTests.Builders
{
    public class TransactionBuilder
    {
        private double value;
        private DateTime date;

        public TransactionBuilder()
        {
            value = 0;
            date = new DateTime(2022, 6, 5);
        }

        public TransactionBuilder WithValue(double value)
        {
            this.value = value;
            return this;
        }

        public TransactionBuilder WithDate(DateTime date)
        {
            this.date = date;
            return this;
        }

        public Transaction Build()
        {
            var transaction = new Transaction(value, date);
            return transaction;
        }
    }
}
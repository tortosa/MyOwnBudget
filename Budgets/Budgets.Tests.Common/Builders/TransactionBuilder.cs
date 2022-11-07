using NodaMoney;
using System;
using Budgets.Domain.Aggregates;

namespace Budgets.Tests.Common.Builders
{
    public class TransactionBuilder
    {
        public int Id { get; private set; }
        public Money Money { get; private set; }
        public DateTime Date { get; private set; }
        public Payee Payee { get; private set; }
        public Category Category { get; private set; }
        public Account Account { get; private set; }

        public TransactionBuilder()
        {
            Id = 0;
            Money = 0;
            Date = new DateTime(2022, 6, 5);
            Payee = new PayeeBuilder().Build();
            Account = new AccountBuilder().Build();
            Category = new CategoryBuilder().Build();
        }

        public TransactionBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public TransactionBuilder WithMoney(Money money)
        {
            this.Money = money;
            return this;
        }

        public TransactionBuilder WithDate(DateTime date)
        {
            this.Date = date;
            return this;
        }

        public TransactionBuilder WithPayee(Payee payee)
        {
            this.Payee = payee;
            return this;
        }

        public TransactionBuilder WithCategory(Category category)
        {
            this.Category = category;
            return this;
        }

        public TransactionBuilder WithAccount(Account account)
        {
            this.Account = account;
            return this;
        }

        public Transaction Build()
        {
            var transaction = new Transaction(Id, Money, Date, Payee, Category, Account);
            return transaction;
        }
    }
}
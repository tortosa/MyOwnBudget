using NodaMoney;
using System;
using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class TransactionBuilder
    {
        private Money money;
        private DateTime date;
        private Payee payee;
        private BudgetCategory budgetCategory;
        private Account account;

        public TransactionBuilder()
        {
            money = 0;
            date = new DateTime(2022, 6, 5);
            payee = new PayeeBuilder().Build();
            account = new AccountBuilder().Build();
            budgetCategory = new BudgetCategoryBuilder().Build();
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

        public TransactionBuilder WithPayee(Payee payee)
        {
            this.payee = payee;
            return this;
        }

        public TransactionBuilder WithBudgetCategory(BudgetCategory budgetCategory)
        {
            this.budgetCategory = budgetCategory;
            return this;
        }

        public TransactionBuilder WithAccount(Account account)
        {
            this.account = account;
            return this;
        }

        public Transaction Build()
        {
            var transaction = new Transaction(money, date, payee, budgetCategory, account);
            return transaction;
        }
    }
}
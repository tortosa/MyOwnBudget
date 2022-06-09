using NodaMoney;
using System;

namespace Budgets.Domain
{
    public class Transaction
    {
        protected Transaction() { }

        public Money Money { get; }
        public DateTime Date { get; }
        public Payee Payee { get; }
        public BudgetCategory BudgetCategory { get; }
        public Account Account { get; }

        public Transaction(Money money, DateTime date, Payee payee, BudgetCategory budgetCategory, Account account)
        {
            Money = money;
            Date = date;
            Payee = payee;
            BudgetCategory = budgetCategory;
            Account = account;

            Account.AddTransactions(this);
            BudgetCategory.AssociateTransaction(this);
        }
    }
}
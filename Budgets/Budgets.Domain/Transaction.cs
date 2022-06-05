using NodaMoney;
using System;

namespace Budgets.Domain
{
    public class Transaction
    {
        protected Transaction() { }

        public Money Money { get; set; }
        public DateTime Date { get; set; }
        public Payee Payee { get; set; }
        public BudgetCategory BudgetCategory { get; set; }
        public Transaction(Money money, DateTime date, Payee payee, BudgetCategory budgetCategory)
        {
            Money = money;
            Date = date;
            Payee = payee;
            BudgetCategory = budgetCategory;
        }
    }
}
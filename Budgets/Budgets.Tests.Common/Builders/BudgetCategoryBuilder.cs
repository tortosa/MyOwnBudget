using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;
using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class BudgetCategoryBuilder
    {
        private string label;
        private Dictionary<MonthYear, Money> moneyAssigned { get; }
        private List<Transaction> transactionsAssociated { get; }

        public BudgetCategoryBuilder()
        {
            moneyAssigned = new Dictionary<MonthYear, Money>();
            transactionsAssociated = new List<Transaction>();
            label = "defaultLabel";
        }

        public BudgetCategoryBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public BudgetCategoryBuilder WithMoneyAssigned(MonthYear monthYear, Money money)
        {
            if(moneyAssigned.ContainsKey(monthYear))
                moneyAssigned.Remove(monthYear);
            this.moneyAssigned.Add(monthYear, money);
            return this;
        }

        public BudgetCategory Build()
        {
            var budgetCategory = new BudgetCategory(label);
            foreach(var dict in moneyAssigned)
            {
                budgetCategory.AssignMoney(dict.Key, dict.Value);
            }

            budgetCategory.AssociateTransaction(transactionsAssociated.ToArray());
            return budgetCategory;
        }
    }
}
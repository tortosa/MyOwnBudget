using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;
using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class BudgetCategoryBuilder
    {
        public int Id { get; private set; }
        public int CategoryGroupId { get; private set; }
        public string Label  { get; private set; }
        public Dictionary<MonthYear, Money> MoneyAssigned  { get; private set; }
        public List<Transaction> TransactionsAssociated  { get; private set; }

        public BudgetCategoryBuilder()
        {
            Id = 0;
            CategoryGroupId = 0;
            MoneyAssigned = new Dictionary<MonthYear, Money>();
            TransactionsAssociated = new List<Transaction>();
            Label = "defaultLabel";
        }

        public BudgetCategoryBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public BudgetCategoryBuilder WithCategoryGroupId(int categoryGroupId)
        {
            this.CategoryGroupId = categoryGroupId;
            return this;
        }

        public BudgetCategoryBuilder WithLabel(string label)
        {
            this.Label = label;
            return this;
        }

        public BudgetCategoryBuilder WithMoneyAssigned(MonthYear monthYear, Money money)
        {
            if(MoneyAssigned.ContainsKey(monthYear))
                MoneyAssigned.Remove(monthYear);
            this.MoneyAssigned.Add(monthYear, money);
            return this;
        }

        public BudgetCategory Build()
        {
            var budgetCategory = new BudgetCategory(Id, Label);
            foreach(var dict in MoneyAssigned)
            {
                budgetCategory.AssignMoney(dict.Key, dict.Value);
            }

            budgetCategory.AssociateTransaction(TransactionsAssociated.ToArray());
            return budgetCategory;
        }
    }
}
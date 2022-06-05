using NodaMoney;
using System.Collections.Generic;

namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetCategoryBuilder
    {
        private string label;
        private List<MoneyAssigned> moneyAssigned;

        public BudgetCategoryBuilder()
        {
            moneyAssigned = new List<MoneyAssigned>();
            label = "defaultLabel";
        }

        public BudgetCategoryBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public BudgetCategoryBuilder WithAssignedMoney(params MoneyAssigned[] moneyAssigned)
        {
            this.moneyAssigned.AddRange(moneyAssigned);
            return this;
        }

        public BudgetCategory Build()
        {
            var budgetCategory = new BudgetCategory(label);
            budgetCategory.AddMoney(moneyAssigned.ToArray());
            return budgetCategory;
        }
    }
}
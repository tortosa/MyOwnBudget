using NodaMoney;

namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetCategoryBuilder
    {
        private string label;
        private BudgetCategoryGroup budgetCategoryGroup;
        private Money assignedMoney;

        public BudgetCategoryBuilder()
        {
            label = "defaultLabel";
        }

        public BudgetCategoryBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }
        public BudgetCategoryBuilder WithBudgetCategoryGroup(BudgetCategoryGroup budgetCategoryGroup)
        {
            this.budgetCategoryGroup = budgetCategoryGroup;
            return this;
        }
        public BudgetCategoryBuilder WithAssignedMoney(Money assignedMoney)
        {
            this.assignedMoney = assignedMoney;
            return this;
        }

        public BudgetCategory Build()
        {
            var budgetCategory = new BudgetCategory(label, budgetCategoryGroup, assignedMoney);
            return budgetCategory;
        }
    }
}
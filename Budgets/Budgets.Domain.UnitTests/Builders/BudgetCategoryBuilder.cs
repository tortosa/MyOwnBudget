using NodaMoney;

namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetCategoryBuilder
    {
        private string label;
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

        public BudgetCategoryBuilder WithAssignedMoney(Money assignedMoney)
        {
            this.assignedMoney = assignedMoney;
            return this;
        }

        public BudgetCategory Build()
        {
            var budgetCategory = new BudgetCategory(label, assignedMoney);
            return budgetCategory;
        }
    }
}
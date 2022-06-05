namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetCategoryBuilder
    {
        private string label;
        private BudgetCategoryGroup budgetCategoryGroup;

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

        public BudgetCategory Build()
        {
            var budgetCategory = new BudgetCategory(label, budgetCategoryGroup);
            return budgetCategory;
        }
    }
}
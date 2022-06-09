using System.Collections.Generic;

namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetCategoryGroupBuilder
    {
        private string label;
        private List<BudgetCategory> budgetCategories { get; }

        public BudgetCategoryGroupBuilder()
        {
            label = "defaultLabel";
            budgetCategories = new List<BudgetCategory>();
        }

        public BudgetCategoryGroupBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }
        public BudgetCategoryGroupBuilder WithBudgetCategories(params BudgetCategory[] budgetCategories)
        {
            this.budgetCategories.AddRange(budgetCategories);
            return this;
        }

        public BudgetCategoryGroup Build()
        {
            var budgetCategory = new BudgetCategoryGroup(label);

            budgetCategory.AddBudgetCategories(budgetCategories.ToArray());
            return budgetCategory;
        }
    }
}
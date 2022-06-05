using System.Collections.Generic;

namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetCategoryGroupBuilder
    {
        private string label;

        public BudgetCategoryGroupBuilder()
        {
            label = "defaultLabel";
        }

        public BudgetCategoryGroupBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public BudgetCategoryGroup Build()
        {
            var budgetCategory = new BudgetCategoryGroup(label);
            return budgetCategory;
        }
    }
}
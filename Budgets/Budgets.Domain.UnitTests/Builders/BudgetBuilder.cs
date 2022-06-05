using System.Collections.Generic;

namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetBuilder
    {
        private string label;
        private string currencyCode;
        private string dateFormat;
        private List<BudgetCategoryGroup> budgetCategoryGroups;

        public BudgetBuilder()
        {
            label = "defaultLabel";
            currencyCode = "EUR";
            budgetCategoryGroups = new List<BudgetCategoryGroup>();
        }

        public BudgetBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public BudgetBuilder WithCurrencyCode(string currencyCode)
        {
            this.currencyCode = currencyCode;
            return this;
        }

        public BudgetBuilder WithDateFormat(string dateFormat)
        {
            this.dateFormat = dateFormat;
            return this;
        }

        public BudgetBuilder WithBudgetCategoryGroups(params BudgetCategoryGroup[] budgetCategoryGroups)
        {
            this.budgetCategoryGroups.AddRange(budgetCategoryGroups);
            return this;
        }

        public Budget Build()
        {
            var budget = new Budget(label, currencyCode, dateFormat);
            budget.AddBudgetCategoryGroups(budgetCategoryGroups.ToArray());
            return budget;
        }
    }
}
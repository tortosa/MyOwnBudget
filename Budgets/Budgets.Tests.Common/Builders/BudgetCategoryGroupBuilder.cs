using Budgets.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Tests.Common.Builders
{
    public class BudgetCategoryGroupBuilder
    {
        public int Id { get; private set; }
        public int BudgetId { get; private set; }
        public string label { get; private set; }
        public List<BudgetCategory> budgetCategories { get; private set; }
        public List<BudgetCategoryBuilder> budgetCategoryBuilders { get; private set; }

        public BudgetCategoryGroupBuilder()
        {
            Id = 0;
            label = "defaultLabel";
            budgetCategories = new List<BudgetCategory>();
            budgetCategoryBuilders = new List<BudgetCategoryBuilder>();
        }

        public BudgetCategoryGroupBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public BudgetCategoryGroupBuilder WithBudgetId(int budgetId)
        {
            this.BudgetId = budgetId;
            return this;
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

        public BudgetCategoryGroupBuilder WithBudgetCategories(params BudgetCategoryBuilder[] budgetCategoryBuilders)
        {
            this.budgetCategoryBuilders.AddRange(budgetCategoryBuilders);
            return this;
        }

        public BudgetCategoryGroup Build()
        {
            var budgetCategory = new BudgetCategoryGroup(Id, label);

            var categoryBuilders = budgetCategoryBuilders.Select(builder => builder.Build());
            var categories = budgetCategories.Concat(categoryBuilders);

            budgetCategory.AddBudgetCategories(categories.ToArray());

            return budgetCategory;
        }
    }
}
using Budgets.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Tests.Common.Builders
{
    public class GroupCategoryBuilder
    {
        public int Id { get; private set; }
        public int BudgetId { get; private set; }
        public string label { get; private set; }
        public List<BudgetCategory> budgetCategories { get; private set; }
        public List<BudgetCategoryBuilder> budgetCategoryBuilders { get; private set; }

        public GroupCategoryBuilder()
        {
            Id = 0;
            label = "defaultLabel";
            budgetCategories = new List<BudgetCategory>();
            budgetCategoryBuilders = new List<BudgetCategoryBuilder>();
        }

        public GroupCategoryBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public GroupCategoryBuilder WithBudgetId(int budgetId)
        {
            this.BudgetId = budgetId;
            return this;
        }

        public GroupCategoryBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public GroupCategoryBuilder WithBudgetCategories(params BudgetCategory[] budgetCategories)
        {
            this.budgetCategories.AddRange(budgetCategories);
            return this;
        }

        public GroupCategoryBuilder WithBudgetCategories(params BudgetCategoryBuilder[] budgetCategoryBuilders)
        {
            this.budgetCategoryBuilders.AddRange(budgetCategoryBuilders);
            return this;
        }

        public GroupCategory Build()
        {
            var budgetCategory = new GroupCategory(Id, label);

            var categoryBuilders = budgetCategoryBuilders.Select(builder => builder.Build());
            var categories = budgetCategories.Concat(categoryBuilders);

            budgetCategory.AddBudgetCategories(categories.ToArray());

            return budgetCategory;
        }
    }
}
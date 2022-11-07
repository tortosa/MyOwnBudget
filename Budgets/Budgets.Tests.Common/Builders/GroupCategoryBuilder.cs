using Budgets.Domain.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Tests.Common.Builders
{
    public class GroupCategoryBuilder
    {
        public int Id { get; private set; }
        public int BudgetId { get; private set; }
        public string Label { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<CategoryBuilder> CategoryBuilders { get; private set; }

        public GroupCategoryBuilder()
        {
            Id = 0;
            Label = "defaultLabel";
            Categories = new List<Category>();
            CategoryBuilders = new List<CategoryBuilder>();
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
            this.Label = label;
            return this;
        }

        public GroupCategoryBuilder WithCategories(params Category[] categories)
        {
            this.Categories.AddRange(categories);
            return this;
        }

        public GroupCategoryBuilder WithCategories(params CategoryBuilder[] categoryBuilders)
        {
            this.CategoryBuilders.AddRange(categoryBuilders);
            return this;
        }

        public GroupCategory Build()
        {
            var category = new GroupCategory(Id, Label);

            var categoryBuilders = CategoryBuilders.Select(builder => builder.Build());
            var categories = Categories.Concat(categoryBuilders);

            category.AddCategories(categories.ToArray());

            return category;
        }
    }
}
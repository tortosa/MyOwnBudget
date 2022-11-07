using Budgets.Domain.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Tests.Common.Builders
{
    public class BudgetBuilder
    {
        public int Id { get; private set; }
        public string Label { get; private set; }
        public string CurrencyCode { get; private set; }
        public string DateFormat { get; private set; }
        public List<GroupCategory> GroupCategories { get; private set; }
        public List<GroupCategoryBuilder> GroupCategoryBuilders { get; private set; }

        public BudgetBuilder()
        {
            Id = 0;
            Label = "defaultLabel";
            CurrencyCode = "EUR";
            GroupCategories = new List<GroupCategory>();
            GroupCategoryBuilders = new List<GroupCategoryBuilder>();
        }

        public BudgetBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public BudgetBuilder WithLabel(string label)
        {
            this.Label = label;
            return this;
        }

        public BudgetBuilder WithCurrencyCode(string currencyCode)
        {
            this.CurrencyCode = currencyCode;
            return this;
        }

        public BudgetBuilder WithDateFormat(string dateFormat)
        {
            this.DateFormat = dateFormat;
            return this;
        }

        public BudgetBuilder WithGroupCategories(params GroupCategory[] GroupCategories)
        {
            this.GroupCategories.AddRange(GroupCategories);
            return this;
        }

        public BudgetBuilder WithGroupCategories(params GroupCategoryBuilder[] GroupCategoryBuilders)
        {
            this.GroupCategoryBuilders.AddRange(GroupCategoryBuilders);
            return this;
        }

        public Budget Build()
        {
            var budget = new Budget(Id, Label, CurrencyCode, DateFormat);
            var categoryGroupBuilders = GroupCategoryBuilders.Select(builder => builder.Build());
            var categoryGroups = GroupCategories.Concat(categoryGroupBuilders);

            budget.AddGroupCategories(categoryGroups.ToArray());
            return budget;
        }
    }
}
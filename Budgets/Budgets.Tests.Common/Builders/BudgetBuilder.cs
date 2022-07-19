using System.Collections.Generic;
using System.Linq;
using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class BudgetBuilder
    {
        public int Id { get; private set; }
        public string Label { get; private set; }
        public string CurrencyCode { get; private set; }
        public string DateFormat { get; private set; }
        public List<BudgetCategoryGroup> BudgetCategoryGroups { get; private set; }
        public List<BudgetCategoryGroupBuilder> BudgetCategoryGroupBuilders { get; private set; }

        public BudgetBuilder()
        {
            Id = 0;
            Label = "defaultLabel";
            CurrencyCode = "EUR";
            BudgetCategoryGroups = new List<BudgetCategoryGroup>();
            BudgetCategoryGroupBuilders = new List<BudgetCategoryGroupBuilder>();
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

        public BudgetBuilder WithBudgetCategoryGroups(params BudgetCategoryGroup[] budgetCategoryGroups)
        {
            this.BudgetCategoryGroups.AddRange(budgetCategoryGroups);
            return this;
        }

        public BudgetBuilder WithBudgetCategoryGroups(params BudgetCategoryGroupBuilder[] budgetCategoryGroupBuilders)
        {
            this.BudgetCategoryGroupBuilders.AddRange(budgetCategoryGroupBuilders);
            return this;
        }

        public Budget Build()
        {
            var budget = new Budget(Id, Label, CurrencyCode, DateFormat);
            var categoryGroupBuilders = BudgetCategoryGroupBuilders.Select(builder => builder.Build());
            var categoryGroups = BudgetCategoryGroups.Concat(categoryGroupBuilders);

            budget.AddBudgetCategoryGroups(categoryGroups.ToArray());
            return budget;
        }
    }
}
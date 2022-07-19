using Budgets.Domain.Specifications.Model;
using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using Xunit;

namespace Budgets.Domain.Specifications.Steps.Given
{
    public static class GivenBuilderFactory
    {
        public static IEnumerable<BudgetBuilder> GivenBudgets(IEnumerable<BudgetModel> budgets)
        {
            var domainBudgets = new List<BudgetBuilder>();

            foreach (var budget in budgets)
            {
                domainBudgets.Add(
                    new BudgetBuilder()
                    .WithId(budget.Id)
                    .WithLabel(budget.Label)
                    .WithDateFormat(budget.DateFormat)
                    .WithCurrencyCode(budget.Currency)
                    );
            }
            return domainBudgets;
        }

        public static IEnumerable<BudgetCategoryGroupBuilder> GivenCategoryGroup(IEnumerable<BudgetCategoryGroupModel> categoryGroupModels)
        {
            var domainCategoryGroup = new List<BudgetCategoryGroupBuilder>();

            foreach (var categoryGroupModel in categoryGroupModels)
            {
                domainCategoryGroup.Add(
                    new BudgetCategoryGroupBuilder()
                    .WithId(categoryGroupModel.Id)
                    .WithBudgetId(categoryGroupModel.BudgetId)
                    .WithLabel(categoryGroupModel.Label)
                    );
            }
            return domainCategoryGroup;
        }

        public static IEnumerable<BudgetCategoryBuilder> GivenCategory(IEnumerable<BudgetCategoryModel> categoryModels)
        {
            var domainCategory = new List<BudgetCategoryBuilder>();

            foreach (var categoryModel in categoryModels)
            {
                domainCategory.Add(
                    new BudgetCategoryBuilder()
                    .WithId(categoryModel.Id)
                    .WithCategoryGroupId(categoryModel.CategoryGroupId)
                    .WithLabel(categoryModel.Label)
                    );
            }
            return domainCategory;
        }
    }
}
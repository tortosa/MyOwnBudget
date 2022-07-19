﻿using Budgets.Domain.Specifications.Model;
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

        public static IEnumerable<GroupCategoryBuilder> GivenGroupCategory(IEnumerable<GroupCategoryModel> groupCategoryModels)
        {
            var domainGroupCategory = new List<GroupCategoryBuilder>();

            foreach (var categoryGroupModel in groupCategoryModels)
            {
                domainGroupCategory.Add(
                    new GroupCategoryBuilder()
                    .WithId(categoryGroupModel.Id)
                    .WithBudgetId(categoryGroupModel.BudgetId)
                    .WithLabel(categoryGroupModel.Label)
                    );
            }
            return domainGroupCategory;
        }

        public static IEnumerable<BudgetCategoryBuilder> GivenCategory(IEnumerable<BudgetCategoryModel> categoryModels)
        {
            var domainCategory = new List<BudgetCategoryBuilder>();

            foreach (var categoryModel in categoryModels)
            {
                domainCategory.Add(
                    new BudgetCategoryBuilder()
                    .WithId(categoryModel.Id)
                    .WithGroupCategoryId(categoryModel.GroupCategoryId)
                    .WithLabel(categoryModel.Label)
                    );
            }
            return domainCategory;
        }
    }
}
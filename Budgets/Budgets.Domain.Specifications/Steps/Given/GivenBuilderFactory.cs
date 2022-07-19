using Budgets.Domain.Specifications.Model;
using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using Xunit;

namespace Budgets.Domain.Specifications.Steps.Given
{
    public static class GivenBuilderFactory
    {
        public static IEnumerable<AccountBuilder> GivenAccounts(IEnumerable<AccountModel> accounts)
        {
            var domainAccounts = new List<AccountBuilder>();

            foreach (var account in accounts)
            {
                domainAccounts.Add(
                    new AccountBuilder()
                    .WithId(account.Id)
                    .WithLabel(account.Label)
                    );
            }
            return domainAccounts;
        }

        public static IEnumerable<PayeeBuilder> GivenPayees(IEnumerable<PayeeModel> payees)
        {
            var domainPayees = new List<PayeeBuilder>();

            foreach (var payee in payees)
            {
                domainPayees.Add(
                    new PayeeBuilder()
                    .WithId(payee.Id)
                    .WithLabel(payee.Label)
                    );
            }
            return domainPayees;
        }

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

        public static IEnumerable<CategoryBuilder> GivenCategory(IEnumerable<CategoryModel> categoryModels)
        {
            var domainCategory = new List<CategoryBuilder>();

            foreach (var categoryModel in categoryModels)
            {
                domainCategory.Add(
                    new CategoryBuilder()
                    .WithId(categoryModel.Id)
                    .WithGroupCategoryId(categoryModel.GroupCategoryId)
                    .WithLabel(categoryModel.Label)
                    );
            }
            return domainCategory;
        }
    }
}
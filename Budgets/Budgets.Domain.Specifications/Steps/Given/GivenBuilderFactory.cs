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
                Assert.False(string.IsNullOrEmpty(budget.Id));

                domainBudgets.Add(
                    new BudgetBuilder()
                    .WithLabel(budget.Label)
                    .WithDateFormat(budget.DateFormat)
                    .WithCurrencyCode(budget.Currency)
                    );
            }
            return domainBudgets;
        }
    }
}
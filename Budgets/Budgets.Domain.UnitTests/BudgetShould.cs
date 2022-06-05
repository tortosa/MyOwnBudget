using Budgets.Domain.UnitTests.Builders;
using System;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class BudgetShould
    {

        /*
        Number Format
        Currency placement
        Date format
         */
        [Fact]
        public void BudgetShouldHaveLabel()
        {
            var expectedLabel = "account name";
            var budget = new BudgetBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.Equal(expectedLabel, budget.Label);
        }

        [Fact]
        public void BudgetShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var budget = new BudgetBuilder()
               .WithLabel(expectedLabel)
               .Build();

            Assert.NotEmpty(budget.Label);
        }

        [Fact]
        public void BudgetShouldHaveCurrencyCode()
        {
            var expectedCurrencyCode = "EUR";
            var budget = new BudgetBuilder()
               .WithCurrencyCode(expectedCurrencyCode)
               .Build();

            Assert.Equal(expectedCurrencyCode, budget.Currency.Code);
        }

        [Fact]
        public void BudgetShouldHaveDateFormat()
        {
            var expectedDateFormat = "YYYY-MM-DD";
            var budget = new BudgetBuilder()
               .WithDateFormat(expectedDateFormat)
               .Build();

            Assert.Equal(expectedDateFormat, budget.DateFormat);
        }
    }
}
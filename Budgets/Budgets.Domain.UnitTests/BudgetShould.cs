using Budgets.Tests.Common.Builders;
using Budgets.Domain.ValueObjects;
using FluentAssertions;
using NodaMoney;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class BudgetShould
    {
        [Fact]
        public void BudgetShouldHaveLabel()
        {
            var expectedLabel = "account name";
            var budget = new BudgetBuilder()
                .WithLabel(expectedLabel)
                .Build();

            budget.Label.Should().Be(expectedLabel);
        }

        [Fact]
        public void BudgetShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var budget = new BudgetBuilder()
               .WithLabel(expectedLabel)
               .Build();

            budget.Label.Should().NotBeEmpty();
        }

        [Fact]
        public void BudgetShouldHaveCurrencyCode()
        {
            var expectedCurrencyCode = "EUR";
            var budget = new BudgetBuilder()
               .WithCurrencyCode(expectedCurrencyCode)
               .Build();

            budget.Currency.Code.Should().Be(expectedCurrencyCode);
        }

        [Fact]
        public void BudgetShouldHaveDateFormat()
        {
            var expectedDateFormat = "YYYY-MM-DD";
            var budget = new BudgetBuilder()
               .WithDateFormat(expectedDateFormat)
               .Build();

            budget.DateFormat.Should().Be(expectedDateFormat);
        }

        [Fact]
        public void BudgetShouldHaveBudgetCategoryGroups()
        {
            var budgetCategoryGroupLabel1 = "Group1";
            var budgetCategoryGroupLabel2 = "Group2";

            var expectedBudgetCategoryGroup1 = new BudgetCategoryGroupBuilder()
                .WithLabel(budgetCategoryGroupLabel1)
                .Build();

            var expectedBudgetCategoryGroup2 = new BudgetCategoryGroupBuilder()
               .WithLabel(budgetCategoryGroupLabel2)
               .Build();

            var budget = new BudgetBuilder()
               .WithBudgetCategoryGroups(expectedBudgetCategoryGroup1, expectedBudgetCategoryGroup2)
               .Build();

            budget.BudgetCategoryGroups.Should().Contain(expectedBudgetCategoryGroup1);
            budget.BudgetCategoryGroups.Should().Contain(expectedBudgetCategoryGroup2);
        }

        [Fact]
        public void BudgetCategoryGroupAssignedMoneyShouldReturnTheAssignedMoneyOfTheirBudgetCategories()
        {
            var money1 = Money.Euro(10);
            var money2 = Money.Euro(20);
            var money3 = Money.Euro(-3);

            var expectedAssigned = money1 + money2 + money3;

            var monthYear = new MonthYear(Month.May, 2022);
            var anotherMonthYear = new MonthYear(Month.April, 2022);

            var budgetCategoryAssigned1 = new BudgetCategoryBuilder()
                .WithMoneyAssigned(monthYear, money1)
                .Build();
            var budgetCategoryAssigned2 = new BudgetCategoryBuilder()
                .WithMoneyAssigned(monthYear, money2)
                .Build();
            var budgetCategoryAssigned3 = new BudgetCategoryBuilder()
                .WithMoneyAssigned(anotherMonthYear, money3)
                .Build();

            var budgetCategoryGroup1 = new BudgetCategoryGroupBuilder()
                .WithBudgetCategories(budgetCategoryAssigned1, budgetCategoryAssigned2)
                .Build();

            var budgetCategoryGroup2 = new BudgetCategoryGroupBuilder()
                .WithBudgetCategories(budgetCategoryAssigned3)
                .Build();

            var budget = new BudgetBuilder()
               .WithBudgetCategoryGroups(budgetCategoryGroup1, budgetCategoryGroup2)
               .Build();

            budget.AssignedMoney.Should().Be(expectedAssigned);
        }
    }
}
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
        public void HaveId()
        {
            var expectedId = 1;
            var budget = new BudgetBuilder()
                .WithId(expectedId)
                .Build();

            Assert.Equal(expectedId, budget.Id);
        }

        [Fact]
        public void HaveLabel()
        {
            var expectedLabel = "account name";
            var budget = new BudgetBuilder()
                .WithLabel(expectedLabel)
                .Build();

            budget.Label.Should().Be(expectedLabel);
        }

        [Fact]
        public void NotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var budget = new BudgetBuilder()
               .WithLabel(expectedLabel)
               .Build();

            budget.Label.Should().NotBeEmpty();
        }

        [Fact]
        public void HaveCurrencyCode()
        {
            var expectedCurrencyCode = "EUR";
            var budget = new BudgetBuilder()
               .WithCurrencyCode(expectedCurrencyCode)
               .Build();

            budget.Currency.Code.Should().Be(expectedCurrencyCode);
        }

        [Fact]
        public void HaveDateFormat()
        {
            var expectedDateFormat = "YYYY-MM-DD";
            var budget = new BudgetBuilder()
               .WithDateFormat(expectedDateFormat)
               .Build();

            budget.DateFormat.Should().Be(expectedDateFormat);
        }

        [Fact]
        public void HaveGroupCategories()
        {
            var GroupCategoryLabel1 = "Group1";
            var GroupCategoryLabel2 = "Group2";

            var expectedGroupCategory1 = new GroupCategoryBuilder()
                .WithLabel(GroupCategoryLabel1)
                .Build();

            var expectedGroupCategory2 = new GroupCategoryBuilder()
               .WithLabel(GroupCategoryLabel2)
               .Build();

            var budget = new BudgetBuilder()
               .WithGroupCategories(expectedGroupCategory1, expectedGroupCategory2)
               .Build();

            budget.GroupCategories.Should().Contain(expectedGroupCategory1);
            budget.GroupCategories.Should().Contain(expectedGroupCategory2);
        }

        [Fact]
        public void GroupCategoryAssignedMoneyShouldReturnTheAssignedMoneyOfTheirCategories()
        {
            var money1 = Money.Euro(10);
            var money2 = Money.Euro(20);
            var money3 = Money.Euro(-3);

            var expectedAssigned = money1 + money2 + money3;

            var monthYear = new MonthYear(Month.May, 2022);
            var anotherMonthYear = new MonthYear(Month.April, 2022);

            var categoryAssigned1 = new CategoryBuilder()
                .WithMoneyAssigned(monthYear, money1)
                .Build();
            var categoryAssigned2 = new CategoryBuilder()
                .WithMoneyAssigned(monthYear, money2)
                .Build();
            var categoryAssigned3 = new CategoryBuilder()
                .WithMoneyAssigned(anotherMonthYear, money3)
                .Build();

            var GroupCategory1 = new GroupCategoryBuilder()
                .WithCategories(categoryAssigned1, categoryAssigned2)
                .Build();

            var GroupCategory2 = new GroupCategoryBuilder()
                .WithCategories(categoryAssigned3)
                .Build();

            var budget = new BudgetBuilder()
               .WithGroupCategories(GroupCategory1, GroupCategory2)
               .Build();

            budget.AssignedMoney.Should().Be(expectedAssigned);
        }
    }
}
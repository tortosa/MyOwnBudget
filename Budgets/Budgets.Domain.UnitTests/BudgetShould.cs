using Budgets.Tests.Common.Builders;
using Budgets.Domain.ValueObjects;
using NodaMoney;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class BudgetShould
    {
        [Fact]
        public void BudgetShouldHaveId()
        {
            var expectedId = 1;
            var budget = new BudgetBuilder()
                .WithId(expectedId)
                .Build();

            Assert.Equal(expectedId, budget.Id);
        }

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

        [Fact]
        public void BudgetShouldHaveGroupCategories()
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

            Assert.Contains(expectedGroupCategory1, budget.GroupCategories);
            Assert.Contains(expectedGroupCategory2, budget.GroupCategories);
        }

        [Fact]
        public void GroupCategoryAssignedMoneyShouldReturnTheAssignedMoneyOfTheirBudgetCategories()
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

            var GroupCategory1 = new GroupCategoryBuilder()
                .WithBudgetCategories(budgetCategoryAssigned1, budgetCategoryAssigned2)
                .Build();

            var GroupCategory2 = new GroupCategoryBuilder()
                .WithBudgetCategories(budgetCategoryAssigned3)
                .Build();

            var budget = new BudgetBuilder()
               .WithGroupCategories(GroupCategory1, GroupCategory2)
               .Build();

            Assert.Equal(expectedAssigned, budget.AssignedMoney);
        }
    }
}
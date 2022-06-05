using Budgets.Domain.UnitTests.Builders;
using Budgets.Domain.ValueObjects;
using NodaMoney;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class BudgetCategoryGroupShould
    {
        [Fact]
        public void BudgetCategoryGroupShouldHaveLabel()
        {
            var expectedLabel = "budgetCategoryGroup name";
            var budgetCategoryGroup = new BudgetCategoryGroupBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.Equal(expectedLabel, budgetCategoryGroup.Label);
        }

        [Fact]
        public void BudgetCategoryGroupShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var budgetCategoryGroup = new BudgetCategoryGroupBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.NotEmpty(budgetCategoryGroup.Label);
        }

        [Fact]
        public void BudgetCategoryGroupAssignedMoneyShouldReturnTheBalanceOfTheirBudgetCategories()
        {
            var money1 = Money.Euro(10);
            var money2 = Money.Euro(20);
            var money3 = Money.Euro(-3);

            var expectedAssigned = money1 + money2;

            var budgetCategoryDate = new MonthYear(Month.May, 2022);
            var anotherBudgetCategoryDate = new MonthYear(Month.April, 2022);

            var moneyAssigned1 = new MoneyAssignedBuilder()
                .WithMoney(money1)
                .WithMonthYear(budgetCategoryDate)
                .Build();

            var moneyAssigned2 = new MoneyAssignedBuilder()
                .WithMoney(money2)
                .WithMonthYear(budgetCategoryDate)
                .Build();

            var moneyAssigned3 = new MoneyAssignedBuilder()
                .WithMoney(money3)
                .WithMonthYear(anotherBudgetCategoryDate)
                .Build();

            var budgetCategoryAssigned1 = new BudgetCategoryBuilder()
                .WithAssignedMoney(moneyAssigned1)
                .Build();
            var budgetCategoryAssigned2 = new BudgetCategoryBuilder()
                .WithAssignedMoney(moneyAssigned2)
                .Build();
            var budgetCategoryAssigned3 = new BudgetCategoryBuilder()
                .WithAssignedMoney(moneyAssigned3)
                .Build();

            var budgetCategoryGroup = new BudgetCategoryGroupBuilder()
                .WithBudgetCategories(budgetCategoryAssigned1, budgetCategoryAssigned2, budgetCategoryAssigned3)
                .Build();

            Assert.Equal(expectedAssigned, budgetCategoryGroup.GetAssignedMoney(budgetCategoryDate));
        }
    }
}
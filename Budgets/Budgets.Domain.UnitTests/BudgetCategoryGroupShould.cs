using Budgets.Domain.UnitTests.Builders;
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

            var budgetCategoryAssigned1 = new BudgetCategoryBuilder()
                .WithAssignedMoney(money1)
                .Build();
            var budgetCategoryAssigned2 = new BudgetCategoryBuilder()
                .WithAssignedMoney(money2)
                .Build();
            var budgetCategoryAssigned3 = new BudgetCategoryBuilder()
                .WithAssignedMoney(money3)
                .Build();

            var budgetCategoryGroup = new BudgetCategoryGroupBuilder()
                .WithBudgetCategories(budgetCategoryAssigned1, budgetCategoryAssigned2)
                .Build();

            Assert.Equal(expectedAssigned, budgetCategoryGroup.AssignedMoney);
        }
    }
}
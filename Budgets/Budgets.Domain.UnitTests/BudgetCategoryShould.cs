using Budgets.Domain.UnitTests.Builders;
using NodaMoney;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class BudgetCategoryShould
    {
        [Fact]
        public void BudgetCategoryShouldHaveLabel()
        {
            var expectedLabel = "budgetCategory name";
            var budgetCategory = new BudgetCategoryBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.Equal(expectedLabel, budgetCategory.Label);             
        }

        [Fact]
        public void BudgetCategoryShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var budgetCategory = new BudgetCategoryBuilder()
               .WithLabel(expectedLabel)
               .Build();

            Assert.NotEmpty(budgetCategory.Label);
        }

        [Fact]
        public void BudgetCategoryShouldHaveABudgetCategoryGroup()
        {
            var expectedLabel = "BudgetCategoryGroup";
            var budgetCategoryGroup = new BudgetCategoryGroupBuilder()
                .WithLabel(expectedLabel)
                .Build();

            var budgetCategory = new BudgetCategoryBuilder()
               .WithBudgetCategoryGroup(budgetCategoryGroup)
               .Build();

            Assert.Equal(expectedLabel, budgetCategory.BudgetCategoryGroup.Label);
        }

        [Fact]
        public void BudgetCategoryShouldHaveAssignedMoney()
        {
            var expectedAssignedMoney = Money.Euro(1250.23);

            var budgetCategory = new BudgetCategoryBuilder()
                .WithAssignedMoney(expectedAssignedMoney)
                .Build();

            Assert.Equal(expectedAssignedMoney, budgetCategory.AssignedMoney);
        }
    }
}
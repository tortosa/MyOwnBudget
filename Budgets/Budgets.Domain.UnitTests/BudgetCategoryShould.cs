using Budgets.Domain.UnitTests.Builders;
using Budgets.Domain.ValueObjects;
using NodaMoney;
using System;
using System.Linq;
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
            var budgetCategory = new BudgetCategoryBuilder()
               .WithLabel(expectedLabel)
               .Build();

            var budgetCategoryGroup = new BudgetCategoryGroupBuilder()
                .WithBudgetCategories(budgetCategory)
                .Build();

            Assert.Equal(expectedLabel, budgetCategoryGroup.BudgetCategories[0].Label);
        }

        [Fact]
        public void BudgetCategoryShouldHaveAssignedMoneyAtMonthYear()
        {
            var budgetCategoryDate = new MonthYear(Month.April, 2030);
            var expectedMoneyAssigned = Money.Euro(1250.23);

            var expectedAssignedMoney = new MoneyAssignedBuilder()
                .WithMoney(expectedMoneyAssigned)
                .WithMonthYear(budgetCategoryDate)
                .Build();

            var budgetCategory = new BudgetCategoryBuilder()
                .WithAssignedMoney(expectedAssignedMoney)
                .Build();

            Assert.Equal(expectedAssignedMoney.AssignedMoney, budgetCategory.MoneyAssigned.Sum(x => (decimal)x.AssignedMoney));
        }

        // TODO: Pending to improve
        [Fact]
        public void BudgetCategoryShouldHaveAvailableMoneyAtMonthYear()
        {
            var transactionDate = new DateTime(2022, 04, 16, 10, 00, 00);

            var budgetCategoryDate = new MonthYear(Month.April, 2022);
            var expectedMoneyAvailable = Money.Euro(1250.23);

            var budgetCategory = new BudgetCategoryBuilder()
                .Build();
            var account = new AccountBuilder()
                .Build();

            var transaction = new TransactionBuilder()
                .WithBudgetCategory(budgetCategory)
                .WithAccount(account)
                .WithMoney(expectedMoneyAvailable)
                .WithDate(transactionDate)
                .Build();

            var anotherTransaction = new TransactionBuilder()
                .WithBudgetCategory(new BudgetCategoryBuilder().Build())
                .WithAccount(account)
                .WithMoney(Money.Euro(5000.00))
                .WithDate(new DateTime(2010, 01, 01))
                .Build();

            Assert.Equal(expectedMoneyAvailable, budgetCategory.GetAvailableMoneyAt(budgetCategoryDate));
        }
    }
}
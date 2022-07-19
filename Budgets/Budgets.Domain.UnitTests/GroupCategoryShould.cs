using Budgets.Domain.ValueObjects;
using Budgets.Tests.Common.Builders;
using NodaMoney;
using System;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class GroupCategoryShould
    {

        [Fact]
        public void GroupCategoryShouldHaveId()
        {
            var expectedId = 1;
            var GroupCategory = new GroupCategoryBuilder()
                .WithId(expectedId)
                .Build();

            Assert.Equal(expectedId, GroupCategory.Id);
        }

        [Fact]
        public void GroupCategoryShouldHaveLabel()
        {
            var expectedLabel = "GroupCategory name";
            var groupCategory = new GroupCategoryBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.Equal(expectedLabel, groupCategory.Label);
        }

        [Fact]
        public void GroupCategoryShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var groupCategory = new GroupCategoryBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.NotEmpty(groupCategory.Label);
        }

        [Fact]
        public void GroupCategoryAssignedMoneyShouldReturnTheBalanceOfTheirBudgetCategories()
        {
            var money1 = Money.Euro(10);
            var money2 = Money.Euro(20);
            var money3 = Money.Euro(-3);

            var expectedAssigned = money1 + money2;

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

            var groupCategory = new GroupCategoryBuilder()
                .WithBudgetCategories(budgetCategoryAssigned1, budgetCategoryAssigned2, budgetCategoryAssigned3)
                .Build();

            Assert.Equal(expectedAssigned, groupCategory.GetAssignedMoney(monthYear));
        }

        [Fact]
        public void GroupCategoryAvailableMoneyShouldReturnTheBalanceOfTheirBudgetCategories()
        {
            var monthYearMay = new MonthYear(Month.May, 2022);
            var monthYearJune = new MonthYear(Month.June, 2022);

            var moneyAssignedInMay = Money.Euro(200);
            var moneyAssignedInJune = Money.Euro(300);

            var moneyTransactionInMay1 = Money.Euro(-50);
            var moneyTransactionInMay2 = Money.Euro(-50);

            var moneyTransactionInJune = Money.Euro(-20);

            var budgetCategoryMay = new BudgetCategoryBuilder()
                .WithMoneyAssigned(monthYearMay, moneyAssignedInMay)
                .Build();

            var budgetCategoryJune = new BudgetCategoryBuilder()
                .WithMoneyAssigned(monthYearJune, moneyAssignedInJune)
                .Build();

            var transactionMay1 = new TransactionBuilder()
                .WithBudgetCategory(budgetCategoryMay)
                .WithMoney(moneyTransactionInMay1)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 16, 10, 00, 00))
                .Build();

            var transactionMay2 = new TransactionBuilder()
                .WithBudgetCategory(budgetCategoryMay)
                .WithMoney(moneyTransactionInMay2)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 20, 10, 00, 00))
                .Build();

            var transactionJune = new TransactionBuilder()
                .WithBudgetCategory(budgetCategoryJune)
                .WithMoney(moneyTransactionInJune)
                .WithDate(new DateTime(monthYearJune.Year, (int)monthYearJune.Month, 20, 10, 00, 00))
                .Build();

            var account = new AccountBuilder()
                .WithTransactions(transactionMay1, transactionMay2, transactionJune)
                .Build();

            var GroupCategory = new GroupCategoryBuilder()
                .WithBudgetCategories(budgetCategoryMay, budgetCategoryJune)
                .Build();

            var expectedMoneyAvailableInJune = moneyAssignedInJune + moneyAssignedInMay + moneyTransactionInMay1 + moneyTransactionInMay2 + moneyTransactionInJune;
            Assert.Equal(expectedMoneyAvailableInJune, GroupCategory.GetAvailableMoneyAt(monthYearJune));
        }
    }
}
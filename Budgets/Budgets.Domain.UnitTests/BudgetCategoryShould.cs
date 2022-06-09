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
            var monthYear = new MonthYear(Month.April, 2030);
            var expectedMoneyAssigned = Money.Euro(1250.23);

            var budgetCategory = new BudgetCategoryBuilder()
                .WithMoneyAssigned(monthYear, expectedMoneyAssigned)
                .Build();

            Assert.Equal(expectedMoneyAssigned, budgetCategory.MoneyAssigned.Sum(moneyAssigned => moneyAssigned.Value.Amount));
        }

        [Fact]
        public void BudgetCategoryShouldKeepLastRecordOfMoneyAssignedAtSameMonthYear()
        {
            var monthYear = new MonthYear(Month.April, 2022);
            var moneyFirst = Money.Euro(1250.23);
            var expectedMoney = Money.Euro(3);
            var budgetCategory = new BudgetCategoryBuilder()
                .WithMoneyAssigned(new MonthYear(Month.April, 2022), moneyFirst)
                .WithMoneyAssigned(new MonthYear(Month.April, 2022), expectedMoney)
                .Build();

            Assert.Equal(expectedMoney, budgetCategory.GetAssignedMoneyAt(monthYear));
        }

        [Fact]
        public void BudgetCategoryShouldHaveRightAvailableMoneyAtNextMonthYear()
        {
            var monthYearMay = new MonthYear(Month.May, 2022);
            var monthYearJune = new MonthYear(Month.June, 2022);

            var moneyAssignedInMay = Money.Euro(200);
            var moneyAssignedInJune = Money.Euro(300);

            var moneyTransactionInMay1 = Money.Euro(-50);
            var moneyTransactionInMay2 = Money.Euro(-50);

            var moneyTransactionInJune = Money.Euro(-20);

            var budgetCategory = new BudgetCategoryBuilder()
                .WithMoneyAssigned(monthYearMay, moneyAssignedInMay)
                .WithMoneyAssigned(monthYearJune, moneyAssignedInJune)
                .Build();

            var transactionMay1 = new TransactionBuilder()
                .WithBudgetCategory(budgetCategory)
                .WithMoney(moneyTransactionInMay1)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 16, 10, 00, 00))
                .Build();

            var transactionMay2 = new TransactionBuilder()
                .WithBudgetCategory(budgetCategory)
                .WithMoney(moneyTransactionInMay2)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 20, 10, 00, 00))
                .Build();

            var transactionJune = new TransactionBuilder()
                .WithBudgetCategory(budgetCategory)
                .WithMoney(moneyTransactionInJune)
                .WithDate(new DateTime(monthYearJune.Year, (int)monthYearJune.Month, 20, 10, 00, 00))
                .Build();

            var account = new AccountBuilder()
                .WithTransactions(transactionMay1, transactionMay2, transactionJune)
                .Build();

            var expectedMoneyAvailableInJune = moneyAssignedInJune + moneyAssignedInMay + moneyTransactionInMay1 + moneyTransactionInMay2 + moneyTransactionInJune;
            Assert.Equal(expectedMoneyAvailableInJune, budgetCategory.GetAvailableMoneyAt(monthYearJune));
        }
    }
}
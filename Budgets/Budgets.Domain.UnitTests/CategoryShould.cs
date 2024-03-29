using Budgets.Tests.Common.Builders;
using Budgets.Domain.ValueObjects;
using NodaMoney;
using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class CategoryShould
    {
        [Fact]
        public void HaveId()
        {
            var expectedId = 1;
            var category = new CategoryBuilder()
                .WithId(expectedId)
                .Build();

            Assert.Equal(expectedId, category.Id);
        }

        [Fact]
        public void HaveLabel()
        {
            var expectedLabel = "category name";
            var category = new CategoryBuilder()
                .WithLabel(expectedLabel)
                .Build();

             category.Label.Should().Be(expectedLabel);           
        }

        [Fact]
        public void NotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var category = new CategoryBuilder()
               .WithLabel(expectedLabel)
               .Build();

            category.Label.Should().NotBeEmpty();
        }

        [Fact]
        public void HaveAGroupCategory()
        {
            var expectedLabel = "GroupCategory";
            var category = new CategoryBuilder()
               .WithLabel(expectedLabel)
               .Build();

            var groupCategory = new GroupCategoryBuilder()
                .WithCategories(category)
                .Build();

            groupCategory.Categories[0].Label.Should().Be(expectedLabel);
        }

        [Fact]
        public void HaveAssignedMoneyAtMonthYear()
        {
            var monthYear = new MonthYear(Month.April, 2030);
            var expectedMoneyAssigned = Money.Euro(1250.23);

            var category = new CategoryBuilder()
                .WithMoneyAssigned(monthYear, expectedMoneyAssigned)
                .Build();

            category.MoneyAssigned.Sum(moneyAssigned => moneyAssigned.Value.Amount).Should().Be(expectedMoneyAssigned.Amount);
        }

        [Fact]
        public void KeepLastRecordOfMoneyAssignedAtSameMonthYear()
        {
            var monthYear = new MonthYear(Month.April, 2022);
            var moneyFirst = Money.Euro(1250.23);
            var expectedMoney = Money.Euro(3);
            var category = new CategoryBuilder()
                .WithMoneyAssigned(new MonthYear(Month.April, 2022), moneyFirst)
                .WithMoneyAssigned(new MonthYear(Month.April, 2022), expectedMoney)
                .Build();

            category.GetAssignedMoneyAt(monthYear).Should().Be(expectedMoney);
        }

        [Fact]
        public void HaveRightAvailableMoneyAtNextMonthYear()
        {
            var monthYearMay = new MonthYear(Month.May, 2022);
            var monthYearJune = new MonthYear(Month.June, 2022);

            var moneyAssignedInMay = Money.Euro(200);
            var moneyAssignedInJune = Money.Euro(300);

            var moneyTransactionInMay1 = Money.Euro(-50);
            var moneyTransactionInMay2 = Money.Euro(-50);

            var moneyTransactionInJune = Money.Euro(-20);

            var category = new CategoryBuilder()
                .WithMoneyAssigned(monthYearMay, moneyAssignedInMay)
                .WithMoneyAssigned(monthYearJune, moneyAssignedInJune)
                .Build();

            var transactionMay1 = new TransactionBuilder()
                .WithCategory(category)
                .WithMoney(moneyTransactionInMay1)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 16, 10, 00, 00))
                .Build();

            var transactionMay2 = new TransactionBuilder()
                .WithCategory(category)
                .WithMoney(moneyTransactionInMay2)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 20, 10, 00, 00))
                .Build();

            var transactionJune = new TransactionBuilder()
                .WithCategory(category)
                .WithMoney(moneyTransactionInJune)
                .WithDate(new DateTime(monthYearJune.Year, (int)monthYearJune.Month, 20, 10, 00, 00))
                .Build();

            var budget = new BudgetBuilder().Build();
            budget.AddTransaction(transactionMay1, transactionMay2, transactionJune);

            var expectedMoneyAvailableInJune = moneyAssignedInJune + moneyAssignedInMay + moneyTransactionInMay1 + moneyTransactionInMay2 + moneyTransactionInJune;
            category.GetAvailableMoneyAt(monthYearJune).Should().Be(expectedMoneyAvailableInJune);
        }

         [Fact]
        public void ReturnZeroMoneyAssignedWhenNothingAssigned()
        {
            var monthYear = new MonthYear(Month.April, 2022);
            var expectedMoney = Money.Euro(0);
            var category = new CategoryBuilder()
                .Build();

            category.GetAssignedMoneyAt(monthYear).Should().Be(expectedMoney);
        }
    }
}
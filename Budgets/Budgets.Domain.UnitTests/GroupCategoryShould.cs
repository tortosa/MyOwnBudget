using Budgets.Domain.ValueObjects;
using Budgets.Tests.Common.Builders;
using NodaMoney;
using System;
using FluentAssertions;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class GroupCategoryShould
    {

        [Fact]
        public void HaveId()
        {
            var expectedId = 1;
            var GroupCategory = new GroupCategoryBuilder()
                .WithId(expectedId)
                .Build();

            Assert.Equal(expectedId, GroupCategory.Id);
        }

        [Fact]
        public void HaveLabel()
        {
            var expectedLabel = "GroupCategory name";
            var groupCategory = new GroupCategoryBuilder()
                .WithLabel(expectedLabel)
                .Build();

            groupCategory.Label.Should().Be(expectedLabel);
        }

        [Fact]
        public void NotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var groupCategory = new GroupCategoryBuilder()
                .WithLabel(expectedLabel)
                .Build();

            groupCategory.Label.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAssignedMoneyFromTheirCategories()
        {
            var money1 = Money.Euro(10);
            var money2 = Money.Euro(20);
            var money3 = Money.Euro(-3);

            var expectedAssigned = money1 + money2;

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

            var groupCategory = new GroupCategoryBuilder()
                .WithCategories(categoryAssigned1, categoryAssigned2, categoryAssigned3)
                .Build();

             groupCategory.GetAssignedMoney(monthYear).Should().Be(expectedAssigned);
        }

        [Fact]
        public void GetAvailableMoneyFromTheirCategories()
        {
            var monthYearMay = new MonthYear(Month.May, 2022);
            var monthYearJune = new MonthYear(Month.June, 2022);

            var moneyAssignedInMay = Money.Euro(200);
            var moneyAssignedInJune = Money.Euro(300);

            var moneyTransactionInMay1 = Money.Euro(-50);
            var moneyTransactionInMay2 = Money.Euro(-50);

            var moneyTransactionInJune = Money.Euro(-20);

            var categoryMay = new CategoryBuilder()
                .WithMoneyAssigned(monthYearMay, moneyAssignedInMay)
                .Build();

            var categoryJune = new CategoryBuilder()
                .WithMoneyAssigned(monthYearJune, moneyAssignedInJune)
                .Build();

            var transactionMay1 = new TransactionBuilder()
                .WithCategory(categoryMay)
                .WithMoney(moneyTransactionInMay1)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 16, 10, 00, 00))
                .Build();

            var transactionMay2 = new TransactionBuilder()
                .WithCategory(categoryMay)
                .WithMoney(moneyTransactionInMay2)
                .WithDate(new DateTime(monthYearMay.Year, (int)monthYearMay.Month, 20, 10, 00, 00))
                .Build();

            var transactionJune = new TransactionBuilder()
                .WithCategory(categoryJune)
                .WithMoney(moneyTransactionInJune)
                .WithDate(new DateTime(monthYearJune.Year, (int)monthYearJune.Month, 20, 10, 00, 00))
                .Build();

            var GroupCategory = new GroupCategoryBuilder()
                .WithCategories(categoryMay, categoryJune)
                .Build();

            var budget = new BudgetBuilder().Build();
            budget.AddTransaction(transactionMay1, transactionMay2, transactionJune);

            var expectedMoneyAvailableInJune = moneyAssignedInJune + moneyAssignedInMay + moneyTransactionInMay1 + moneyTransactionInMay2 + moneyTransactionInJune;
            GroupCategory.GetAvailableMoneyAt(monthYearJune).Should().Be(expectedMoneyAvailableInJune);
        }
    }
}
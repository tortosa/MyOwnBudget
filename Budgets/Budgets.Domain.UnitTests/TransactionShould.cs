using Budgets.Domain.UnitTests.Builders;
using NodaMoney;
using System;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class TransactionShould
    {
        [Fact]
        public void TransactionShouldHaveMoney()
        {
            var expectedMoney = Money.Euro(6.54);

            var transaction = new TransactionBuilder()
                .WithMoney(expectedMoney)
                .Build();

            Assert.Equal(expectedMoney, transaction.Money);             
        }

        [Fact]
        public void TransactionShouldHaveDate()
        {
            var expectedDate = new DateTime(2022, 6, 5, 12, 30, 20);
            var transaction = new TransactionBuilder()
                .WithDate(expectedDate)
                .Build();

            Assert.Equal(expectedDate, transaction.Date);
        }

        [Fact]
        public void TransactionShouldHaveBudgetCategory()
        {
            var expectedBudgetCategory = new BudgetCategoryBuilder()
                .Build();

            var transaction = new TransactionBuilder()
                .WithBudgetCategory(expectedBudgetCategory)
                .Build();

            Assert.Equal(expectedBudgetCategory, transaction.BudgetCategory);
        }

        [Fact]
        public void TransactionShouldHavePayee()
        {
            var expectedLabel = "Payee";
            var payee = new PayeeBuilder()
                .WithLabel(expectedLabel)
                .Build();

            var transaction = new TransactionBuilder()
                .WithPayee(payee)
                .Build();

            Assert.Equal(expectedLabel, transaction.Payee.Label);
        }
    }
}
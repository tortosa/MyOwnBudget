using Budgets.Domain.UnitTests.Builders;
using System;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class TransactionShould
    {
        [Fact]
        public void TransactionShouldHaveValue()
        {
            var expectedValue = 151.32;

            var transaction = new TransactionBuilder()
                .WithValue(expectedValue)
                .Build();

            Assert.Equal(expectedValue, transaction.Value);             
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
            var expectedDate = new DateTime(2022, 6, 5, 12, 30, 20);
            var transaction = new TransactionBuilder()
                .WithDate(expectedDate)
                .Build();

            Assert.Equal(expectedDate, transaction.Date);
        }
    }
}
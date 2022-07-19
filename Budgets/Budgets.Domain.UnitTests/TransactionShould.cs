using Budgets.Tests.Common.Builders;
using NodaMoney;
using System;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class TransactionShould
    {
        [Fact]
        public void PayeeTransactionShouldHaveId()
        {
            var expectedId = 1;
            var transaction = new TransactionBuilder()
                .WithId(expectedId)
                .Build();

            Assert.Equal(expectedId, transaction.Id);
        }

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
        public void TransactionShouldHaveCategory()
        {
            var expectedCategory = new CategoryBuilder()
                .Build();

            var transaction = new TransactionBuilder()
                .WithCategory(expectedCategory)
                .Build();

            Assert.Equal(expectedCategory, transaction.Category);
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

        [Fact]
        public void TransactionShouldHaveAccount()
        {
            var expectedAccount = new AccountBuilder()
                .Build();

            var transaction = new TransactionBuilder()
                .WithAccount(expectedAccount)
                .Build();

            Assert.Equal(expectedAccount, transaction.Account);
        }
    }
}
using Budgets.Tests.Common.Builders;
using NodaMoney;
using System;
using Xunit;
using FluentAssertions;

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

            transaction.Id.Should().Be(expectedId);
        }

        [Fact]
        public void TransactionShouldHaveMoney()
        {
            var expectedMoney = Money.Euro(6.54);

            var transaction = new TransactionBuilder()
                .WithMoney(expectedMoney)
                .Build();

            transaction.Money.Should().Be(expectedMoney);
        }

        [Fact]
        public void TransactionShouldHaveDate()
        {
            var expectedDate = new DateTime(2022, 6, 5, 12, 30, 20);
            var transaction = new TransactionBuilder()
                .WithDate(expectedDate)
                .Build();

            transaction.Date.Should().Be(expectedDate);
        }

        [Fact]
        public void TransactionShouldHaveCategory()
        {
            var expectedCategory = new CategoryBuilder()
                .Build();

            var transaction = new TransactionBuilder()
                .WithCategory(expectedCategory)
                .Build();

            transaction.Category.Should().Be(expectedCategory);
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

            transaction.Payee.Label.Should().Be(expectedLabel);
        }

        [Fact]
        public void TransactionShouldHaveAccount()
        {
            var expectedAccount = new AccountBuilder()
                .Build();

            var transaction = new TransactionBuilder()
                .WithAccount(expectedAccount)
                .Build();

            transaction.Account.Should().Be(expectedAccount);
        }
    }
}
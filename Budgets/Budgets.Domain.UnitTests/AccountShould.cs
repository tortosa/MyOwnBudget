using Budgets.Domain.UnitTests.Builders;
using System;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class AccountShould
    {
        [Fact]
        public void AccountShouldHaveLabel()
        {
            var expectedLabel = "account name";
            var account = new AccountBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.Equal(expectedLabel, account.Label);             
        }

        [Fact]
        public void AccountShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var account = new AccountBuilder()
               .WithLabel(expectedLabel)
               .Build();

            Assert.NotEmpty(account.Label);
        }

        [Fact]
        public void AccountShouldReturnBalanceOfTransactions()
        {
            var sum1 = 182.31;
            var sum2 = -21.43;
            var expectedBalance = sum1 + sum2;

            var transaction1 = new TransactionBuilder()
                .WithValue(sum1)
                .Build();
            var transaction2 = new TransactionBuilder()
                .WithValue(sum2)
                .Build();

            var account = new AccountBuilder()
               .WithTransactions(transaction1, transaction2)
               .Build();

            Assert.Equal(expectedBalance, account.Balance);
        }
    }
}
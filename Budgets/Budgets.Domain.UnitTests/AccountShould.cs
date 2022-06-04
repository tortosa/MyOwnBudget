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
            var account = new Account(expectedLabel);

            Assert.Equal(expectedLabel, account.Label);             
        }

        [Fact]
        public void AccountShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var account = new Account(expectedLabel);

            Assert.NotEmpty(account.Label);
        }

        [Fact]
        public void AccountShouldReturnBalanceOfTransactions()
        {
            var sum1 = 182.31;
            var sum2 = -21.43;
            var expectedBalance = sum1 + sum2;

            var transaction1 = new Transaction(sum1);
            var transaction2 = new Transaction(sum2);

            var account = new Account("temp");

            account.AddTransactions(transaction1, transaction2);

            Assert.Equal(expectedBalance, account.Balance);
        }
    }
}
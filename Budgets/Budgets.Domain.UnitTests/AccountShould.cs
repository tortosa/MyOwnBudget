using NodaMoney;
using Xunit;
using Budgets.Tests.Common.Builders;
using FluentAssertions;

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

            account.Label.Should().Be(expectedLabel);
        }

        [Fact]
        public void AccountShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var account = new AccountBuilder()
               .WithLabel(expectedLabel)
               .Build();

            account.Label.Should().NotBeEmpty();
        }

        [Fact]
        public void AccountShouldReturnBalanceOfTransactions()
        {
            var sum1 = 182.31;
            var sum2 = -21.43;
            var expectedBalance = Money.Euro(sum1) + Money.Euro(sum2);

            var transaction1 = new TransactionBuilder()
                .WithMoney(Money.Euro(sum1))
                .Build();
            var transaction2 = new TransactionBuilder()
                .WithMoney(Money.Euro(sum2))
                .Build();

            var account = new AccountBuilder()
               .WithTransactions(transaction1, transaction2)
               .Build();

            account.Balance.Should().Be(expectedBalance);
        }

        [Fact]
        public void AccountDecreaseWhenTransactionIsAssociated()
        {
            var moneyAdded = Money.Euro(12);

            var transaction1 = new TransactionBuilder()
                .WithMoney(moneyAdded)
                .WithAccount(new AccountBuilder().Build())
                .Build();

            transaction1.Account.Balance.Should().Be(moneyAdded);
        }
    }
}
using Budgets.Domain.UnitTests.Builders;
using NodaMoney;
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

            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        public void AccountDecreaseWhenTransactionIsAssociated()
        {
            var account = new AccountBuilder()
               .Build();

            var moneyAdded = Money.Euro(12);

            var transaction1 = new TransactionBuilder()
                .WithMoney(moneyAdded)
                .WithAccount(account)
                .Build();

            Assert.Equal(moneyAdded, transaction1.Account.Balance);
        }
    }
}
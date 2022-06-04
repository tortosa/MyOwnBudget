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
    }
}
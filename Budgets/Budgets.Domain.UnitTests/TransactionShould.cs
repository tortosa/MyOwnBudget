using System;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class TransactionShould
    {
        [Fact]
        public void AccountShouldHaveValue()
        {
            var value = 151.32;
            var transaction = new Transaction(value);

            Assert.Equal(value, transaction.Value);             
        }
    }
}
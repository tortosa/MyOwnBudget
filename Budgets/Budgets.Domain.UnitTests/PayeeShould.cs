using Budgets.Domain.UnitTests.Builders;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class PayeeShould
    {
        [Fact]
        public void PayeeShouldHaveLabel()
        {
            var expectedLabel = "budgetCategoryGroup name";
            var payee = new PayeeBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.Equal(expectedLabel, payee.Label);             
        }

        [Fact]
        public void PayeeShouldShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var payee = new PayeeBuilder()
                .WithLabel(expectedLabel)
                .Build();

            Assert.NotEmpty(payee.Label);
        }
    }
}
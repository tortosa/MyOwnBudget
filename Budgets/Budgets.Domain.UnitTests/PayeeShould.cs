using Budgets.Tests.Common.Builders;
using FluentAssertions;
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

            payee.Label.Should().Be(expectedLabel);             
        }

        [Fact]
        public void PayeeShouldShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var payee = new PayeeBuilder()
                .WithLabel(expectedLabel)
                .Build();

            payee.Label.Should().NotBeEmpty();
        }
    }
}
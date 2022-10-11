using Budgets.Tests.Common.Builders;
using FluentAssertions;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class PayeeShould
    {
        [Fact]
        public void HaveId()
        {
            var expectedId = 1;
            var payee = new PayeeBuilder()
                .WithId(expectedId)
                .Build();

            Assert.Equal(expectedId, payee.Id);
        }

        [Fact]
        public void HaveLabel()
        {
            var expectedLabel = "GroupCategory name";
            var payee = new PayeeBuilder()
                .WithLabel(expectedLabel)
                .Build();

            payee.Label.Should().Be(expectedLabel);             
        }

        [Fact]
        public void ShouldNotAllowEmptyLabel()
        {
            var expectedLabel = string.Empty;
            var payee = new PayeeBuilder()
                .WithLabel(expectedLabel)
                .Build();

            payee.Label.Should().NotBeEmpty();
        }
    }
}
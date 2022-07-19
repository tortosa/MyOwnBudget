using Budgets.Application.Controllers;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using FluentAssertions;

namespace Budgets.Application.UnitTests
{
    public class BudgetControllerShould
    {
        private readonly BudgetController budgetController;

        public BudgetControllerShould()
        {
            budgetController = new BudgetController(new Mock<ILogger<BudgetController>>().Object);
        }

        [Fact]
        public void GetTest_ReturnsBudget()
        {
            var result = budgetController.Get();
            result.Should().NotBeNull();
        }
    }
}
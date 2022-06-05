using Budgets.Domain.ValueObjects;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class MonthYearShould
    {
        [Fact]
        public void MonthYearShouldBeEqualToAnotherInstanceWithSameValues()
        {
            var month = Month.May;
            var year = 2022;

            var monthYear = new MonthYear(month, year);
            var anotherMonthYear = new MonthYear(month, year);

            Assert.Equal(monthYear, anotherMonthYear);             
        }
    }
}
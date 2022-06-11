using Budgets.Domain.ValueObjects;
using Xunit;

namespace Budgets.Domain.UnitTests
{
    public class MonthYearShould
    {
        [Fact]
        public void MonthYearShouldReturnSameThanOperators()
        {
            MonthYear monthYearNull = null;
            var monthYear = new MonthYear(Month.January, 2022);
            Assert.False(monthYearNull == monthYear);
            Assert.False(monthYear.Equals(monthYearNull));
            Assert.True(monthYear.Equals(monthYear));
            Assert.True(monthYearNull == monthYearNull);
            Assert.False(monthYear.Equals(new string("test")));
            Assert.False(monthYear != new MonthYear(Month.January, 2022));
        }

        [Fact]
        public void MonthYearShouldBeEqualToAnotherInstanceWithSameValues()
        {
            var month = Month.May;
            var year = 2022;

            var monthYear = new MonthYear(month, year);
            var anotherMonthYear = new MonthYear(month, year);

            Assert.Equal(monthYear, anotherMonthYear);             
        }

        [Fact]
        public void MonthYearShouldBeEqualToAnotherInstanceWithSameValuesWithOperator()
        {
            var month = Month.May;
            var year = 2022;

            var monthYear = new MonthYear(month, year);
            var anotherMonthYear = new MonthYear(month, year);

            var equalComparator = monthYear == anotherMonthYear;
            Assert.True(equalComparator);
        }

        [Fact]
        public void MonthYearShouldReturnPreviousMonth()
        {
            var expectedMonth = Month.April;
            var month = Month.May;
            var year = 2022;
            var monthYear = new MonthYear(month, year);
            var previousMonthYear = monthYear.GetPreviousMonth();

            Assert.Equal(expectedMonth, previousMonthYear.Month);
            Assert.Equal(year, previousMonthYear.Year);
        }

        [Fact]
        public void MonthYearShouldReturnPreviousMonthChangingYear()
        {
            var expectedMonth = Month.December;
            var month = Month.January;
            var year = 2022;
            var monthYear = new MonthYear(month, year);
            var previousMonthYear = monthYear.GetPreviousMonth();

            Assert.Equal(expectedMonth, previousMonthYear.Month);
            Assert.Equal(year - 1, previousMonthYear.Year);
        }
    }
}
using Budgets.Domain.ValueObjects;
using FluentAssertions;
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

            (monthYearNull == monthYear).Should().BeFalse();
            (monthYear.Equals(monthYearNull)).Should().BeFalse();
            monthYear.Equals(monthYear).Should().BeTrue();
            (monthYearNull == monthYearNull).Should().BeTrue();
        }

        [Fact]
        public void MonthYearShouldBeEqualToAnotherInstanceWithSameValues()
        {
            var month = Month.May;
            var year = 2022;

            var monthYear = new MonthYear(month, year);
            var anotherMonthYear = new MonthYear(month, year);

            monthYear.Should().Be(anotherMonthYear);       
        }

        [Fact]
        public void MonthYearShouldBeEqualToAnotherInstanceWithSameValuesWithOperator()
        {
            var month = Month.May;
            var year = 2022;

            var monthYear = new MonthYear(month, year);
            var anotherMonthYear = new MonthYear(month, year);

            var equalComparator = monthYear == anotherMonthYear;
            equalComparator.Should().BeTrue();
        }

        [Fact]
        public void MonthYearShouldReturnPreviousMonth()
        {
            var expectedMonth = Month.April;
            var month = Month.May;
            var year = 2022;
            var monthYear = new MonthYear(month, year);
            var previousMonthYear = monthYear.GetPreviousMonth();

            previousMonthYear.Month.Should().Be(expectedMonth);
            previousMonthYear.Year.Should().Be(year);
        }

        [Fact]
        public void MonthYearShouldReturnPreviousMonthChangingYear()
        {
            var expectedMonth = Month.December;
            var month = Month.January;
            var year = 2022;
            var monthYear = new MonthYear(month, year);
            var previousMonthYear = monthYear.GetPreviousMonth();
            
            previousMonthYear.Month.Should().Be(expectedMonth);
            previousMonthYear.Year.Should().Be(year - 1);
        }
    }
}
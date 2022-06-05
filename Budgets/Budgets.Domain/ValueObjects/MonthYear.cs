using System;

namespace Budgets.Domain.ValueObjects
{
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class MonthYear : IEquatable<MonthYear>
    {
        public Month Month { get; }
        public int Year { get; }

        public MonthYear(Month month, int year)
        {
            Month = month;
            Year = year;
        }

        public bool Equals(MonthYear monthYear)
        {
            if (monthYear is null)
            {
                return false;
            }

            if (ReferenceEquals(this, monthYear))
            {
                return true;
            }

            if (this.GetType() != monthYear.GetType())
            {
                return false;
            }

            return (this.Month == monthYear.Month) && (this.Year == monthYear.Year);
        }

        public override bool Equals(object obj) => this.Equals(obj as MonthYear);

        public override int GetHashCode() => (this.Month, this.Year).GetHashCode();
    }
}
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

        public MonthYear GetPreviousMonth()
        {
            var month = (int)Month -1;
            var year = Year;
            if(month == 0)
            {
                month = 12;
                --year;
            }

            return new MonthYear((Month)month, year);
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

        public static bool operator ==(MonthYear op1, MonthYear op2)
        {
            if (op1 is null)
            {
                if (op2 is null)
                    return true;
                
                return false;
            }
            return op1.Equals(op2);
        }

        public static bool operator !=(MonthYear op1, MonthYear op2) => !(op1 == op2);
    }
}
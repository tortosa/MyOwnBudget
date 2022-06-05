using Budgets.Domain.ValueObjects;
using NodaMoney;

namespace Budgets.Domain
{
    public class MoneyAssigned
    {
        protected MoneyAssigned() { }

        public MonthYear MonthYear { get; set; }
        public Money AssignedMoney { get; set; }

         
        public MoneyAssigned(MonthYear monthYear, Money assignedMoney)
        {
            this.MonthYear = monthYear;
            this.AssignedMoney = assignedMoney;
        }
    }
}
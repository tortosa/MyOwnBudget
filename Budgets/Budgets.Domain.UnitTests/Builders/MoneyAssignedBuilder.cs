using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;

namespace Budgets.Domain.UnitTests.Builders
{
    public class MoneyAssignedBuilder
    {
        private MonthYear monthYear { get; set; }
        private Money assignedMoney { get; set; }

        public MoneyAssignedBuilder()
        {
            assignedMoney = Money.Euro(0);
            monthYear = new MonthYear(Month.January, 2022);
        }

        public MoneyAssignedBuilder WithMoney(Money assignedMoney)
        {
            this.assignedMoney = assignedMoney;
            return this;
        }

        public MoneyAssignedBuilder WithMonthYear(MonthYear monthYear)
        {
            this.monthYear = monthYear;
            return this;
        }

        public MoneyAssigned Build()
        {
            var moneyAssigned = new MoneyAssigned(monthYear, assignedMoney);
            return moneyAssigned;
        }
    }
}
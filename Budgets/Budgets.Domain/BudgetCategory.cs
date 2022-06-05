using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class BudgetCategory
    {
        protected BudgetCategory() { }

        public string Label { get; set; }

        public Dictionary<MonthYear, Money> MoneyAssigned { get; }

        public List<Transaction> TransactionsAssociated { get; }

        public BudgetCategory(string label)
        {
            MoneyAssigned = new Dictionary<MonthYear, Money>();
            TransactionsAssociated = new List<Transaction>();

            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategory label";
            Label = label;
        }

        public void AssignMoney(MonthYear monthYear, Money money)
        {
            MoneyAssigned.Add(monthYear, money);
        }

        public void AssociateTransaction(params Transaction[] transactionsAssociated)
        {
            TransactionsAssociated.AddRange(transactionsAssociated);
        }

        public Money GetAvailableMoneyAt(MonthYear monthYear)
        {
            var transactionsAt = TransactionsAssociated.Where(transaction => monthYear.Year == transaction.Date.Year && (int)monthYear.Month == transaction.Date.Month).ToList();
            var moneyAssignedAt = MoneyAssigned.Where(assigned => assigned.Key == monthYear).ToList();

            var availableAt = moneyAssignedAt.Sum(x => (decimal)x.Value);

            return TransactionsAssociated
                .Where(transaction => monthYear.Year == transaction.Date.Year && (int)monthYear.Month == transaction.Date.Month)
                .Sum(transaction => (decimal)transaction.Money);
        }

        public Money GetAssignedMoneyAt(MonthYear monthYear)
        {
            return MoneyAssigned[monthYear];
        }
    }
}
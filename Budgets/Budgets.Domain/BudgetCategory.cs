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
        public List<MoneyAssigned> MoneyAssigned { get; set; }
        public List<Transaction> TransactionsAssociated { get; set; }

        public BudgetCategory(string label)
        {
            MoneyAssigned = new List<MoneyAssigned>();
            TransactionsAssociated = new List<Transaction>();

            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategory label";
            Label = label;
        }

        public void AddMoney(params MoneyAssigned[] moneyAssigned)
        {
            MoneyAssigned.AddRange(moneyAssigned);
        }

        public void AssociateTransaction(params Transaction[] transactionsAssociated)
        {
            TransactionsAssociated.AddRange(transactionsAssociated);
        }

        public Money GetAvailableMoneyAt(MonthYear monthYear)
        {
            var transactionsAt = TransactionsAssociated.Where(transaction => monthYear.Year == transaction.Date.Year && (int)monthYear.Month == transaction.Date.Month).ToList();
            var moneyAssignedAt = MoneyAssigned.Where(assigned => assigned.MonthYear == monthYear).ToList();

            var availableAt = moneyAssignedAt.Sum(x => (decimal)x.AssignedMoney);

            return TransactionsAssociated
                .Where(transaction => monthYear.Year == transaction.Date.Year && (int)monthYear.Month == transaction.Date.Month)
                .Sum(transaction => (decimal)transaction.Money);
        }
    }
}
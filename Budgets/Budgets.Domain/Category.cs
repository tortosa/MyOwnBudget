using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class Category
    {
        protected Category() { }

        public int Id { get; }
        public string Label { get; }
        public Dictionary<MonthYear, Money> MoneyAssigned { get; }
        public List<Transaction> TransactionsAssociated { get; }

        public Category(int id, string label)
        {
            MoneyAssigned = new Dictionary<MonthYear, Money>();
            TransactionsAssociated = new List<Transaction>();

            if (string.IsNullOrEmpty(label))
                label = "Default Category label";
            Label = label;
            Id = id;
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
            var previousMonthYear = monthYear.GetPreviousMonth();

            var previousMonthMoneyAssigned = MoneyAssigned.Where(assigned => previousMonthYear == assigned.Key).ToList();
            var moneyAssigned = MoneyAssigned.Where(assigned => monthYear == assigned.Key).ToList();

            var previusMonthTransactions = TransactionsAssociated.Where(transaction => previousMonthYear.Year == transaction.Date.Year && (int)previousMonthYear.Month == transaction.Date.Month).ToList();
            var transactionsAt = TransactionsAssociated.Where(transaction => monthYear.Year == transaction.Date.Year && (int)monthYear.Month == transaction.Date.Month).ToList();

            var availableAt =
                previousMonthMoneyAssigned.Sum(transaction => transaction.Value.Amount) +
                moneyAssigned.Sum(transaction => transaction.Value.Amount) +
                previusMonthTransactions.Sum(transaction => transaction.Money.Amount) +
                transactionsAt.Sum(transaction => transaction.Money.Amount);

            return availableAt;
        }

        public Money GetAssignedMoneyAt(MonthYear monthYear)
        {
            if(!MoneyAssigned.ContainsKey(monthYear))
                return 0;
            return MoneyAssigned[monthYear];
        }
    }
}
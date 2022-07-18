using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class Budget
    {
        protected Budget() { }
        public int Id { get; }
        public string Label { get; }
        public string DateFormat { get; }
        public Currency Currency { get; }
        public List<BudgetCategoryGroup> BudgetCategoryGroups { get; }
        public Money AssignedMoney => GetAssignedMoney();

        public Budget(int id, string label, string currencyCode, string dateFormat)
        {
            BudgetCategoryGroups = new List<BudgetCategoryGroup>();

            if (string.IsNullOrEmpty(label))
                label = "Default account label";
            Id = id;
            Label = label;
            Currency = Currency.FromCode(currencyCode);
            DateFormat = dateFormat;
        }

        public void AddBudgetCategoryGroups(params BudgetCategoryGroup[] budgetCategoryGroups)
        {
            BudgetCategoryGroups.AddRange(budgetCategoryGroups);
        }

        private Money GetAssignedMoney()
        {
            return BudgetCategoryGroups.Sum(transaction => transaction.AssignedMoney.Amount);
        }
    }
}
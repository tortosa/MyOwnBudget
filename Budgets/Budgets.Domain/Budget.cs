using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class Budget
    {
        protected Budget() { }
        public string Label { get; set; }
        public string DateFormat { get; set; }
        public Currency Currency;
        public List<BudgetCategoryGroup> BudgetCategoryGroups { get; }
        public Money AssignedMoney => GetAssignedMoney();

        public Budget(string label, string currencyCode, string dateFormat)
        {
            BudgetCategoryGroups = new List<BudgetCategoryGroup>();

            if (string.IsNullOrEmpty(label))
                label = "Default account label";
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
            return BudgetCategoryGroups.Sum(transaction => (decimal)transaction.AssignedMoney);
        }
    }
}
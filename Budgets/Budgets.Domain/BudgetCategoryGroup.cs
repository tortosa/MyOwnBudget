using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class BudgetCategoryGroup
    {
        protected BudgetCategoryGroup() { }

        public string Label { get; set; }
        public List<BudgetCategory> BudgetCategories { get; }
        public Money AssignedMoney => GetBalance();

        private Money GetBalance()
        {
            return BudgetCategories.Sum(budgetCategories => (decimal)budgetCategories.AssignedMoney);
        }

        public BudgetCategoryGroup(string label)
        {
            BudgetCategories = new List<BudgetCategory>();

            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategoryGroup label";
            Label = label;
        }

        public void AddBudgetCategories(params BudgetCategory[] budgetCategories)
        {
            BudgetCategories.AddRange(budgetCategories);
        }
    }
}
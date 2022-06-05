using Budgets.Domain.ValueObjects;
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
        public Money AssignedMoney => GetAssignedMoney();

        private Money GetAssignedMoney()
        {
            return BudgetCategories.Sum(budgetCategories => (decimal)budgetCategories.MoneyAssigned.Sum(x => (decimal)x.AssignedMoney));
        }

        public Money GetAssignedMoney(MonthYear monthYear)
        {
            return BudgetCategories
                .Select(category => category.MoneyAssigned)                
                .SelectMany(moneyAssigned => moneyAssigned.Where(x => x.MonthYear == monthYear))
                .Sum(money => (decimal)money.AssignedMoney);
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
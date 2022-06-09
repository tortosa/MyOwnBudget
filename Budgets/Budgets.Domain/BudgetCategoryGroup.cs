using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class BudgetCategoryGroup
    {
        protected BudgetCategoryGroup() { }

        public string Label { get; }
        public List<BudgetCategory> BudgetCategories { get; }
        public Money AssignedMoney => GetAssignedMoney();

        private Money GetAssignedMoney()
        {
            return BudgetCategories.Sum(budgetCategory => budgetCategory.MoneyAssigned.Sum(moneyAssigned => moneyAssigned.Value.Amount));
        }

        public Money GetAssignedMoney(MonthYear monthYear)
        {
            return BudgetCategories
                .Select(category => category.MoneyAssigned)                
                .SelectMany(moneyAssigned => moneyAssigned.Where(moneyAssigned => moneyAssigned.Key == monthYear))
                .Sum(money => money.Value.Amount);
        }

        public Money GetAvailableMoneyAt(MonthYear monthYear)
        {
            return BudgetCategories
                .Select(category => category.GetAvailableMoneyAt(monthYear))
                .Sum(money => money.Amount);
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
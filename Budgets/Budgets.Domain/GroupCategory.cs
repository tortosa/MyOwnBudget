using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain
{
    public class GroupCategory
    {
        protected GroupCategory() { }

        public int Id { get; }
        public string Label { get; }
        public List<BudgetCategory> BudgetCategories { get; }
        public Money AssignedMoney => GetAssignedMoney();

        public GroupCategory(int id, string label)
        {
            BudgetCategories = new List<BudgetCategory>();

            if (string.IsNullOrEmpty(label))
                label = "Default GroupCategory label";
            Label = label;
            Id = id;
        }

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

        public void AddBudgetCategories(params BudgetCategory[] budgetCategories)
        {
            BudgetCategories.AddRange(budgetCategories);
        }
    }
}
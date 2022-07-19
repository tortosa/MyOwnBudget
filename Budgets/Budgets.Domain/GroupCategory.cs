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
        public List<Category> Categories { get; }
        public Money AssignedMoney => GetAssignedMoney();

        public GroupCategory(int id, string label)
        {
            Categories = new List<Category>();

            if (string.IsNullOrEmpty(label))
                label = "Default GroupCategory label";
            Label = label;
            Id = id;
        }

        private Money GetAssignedMoney()
        {
            return Categories.Sum(category => category.MoneyAssigned.Sum(moneyAssigned => moneyAssigned.Value.Amount));
        }

        public Money GetAssignedMoney(MonthYear monthYear)
        {
            return Categories
                .Select(category => category.MoneyAssigned)                
                .SelectMany(moneyAssigned => moneyAssigned.Where(moneyAssigned => moneyAssigned.Key == monthYear))
                .Sum(money => money.Value.Amount);
        }

        public Money GetAvailableMoneyAt(MonthYear monthYear)
        {
            return Categories
                .Select(category => category.GetAvailableMoneyAt(monthYear))
                .Sum(money => money.Amount);
        }

        public void AddCategories(params Category[] categories)
        {
            Categories.AddRange(categories);
        }
    }
}
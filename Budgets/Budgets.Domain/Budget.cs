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
        public List<GroupCategory> GroupCategories { get; }
        public Money AssignedMoney => GetAssignedMoney();

        public Budget(int id, string label, string currencyCode, string dateFormat)
        {
            GroupCategories = new List<GroupCategory>();

            if (string.IsNullOrEmpty(label))
                label = "Default account label";
            Id = id;
            Label = label;
            Currency = Currency.FromCode(currencyCode);
            DateFormat = dateFormat;
        }

        public void AddGroupCategories(params GroupCategory[] GroupCategories)
        {
            this.GroupCategories.AddRange(GroupCategories);
        }

        private Money GetAssignedMoney()
        {
            return GroupCategories.Sum(transaction => transaction.AssignedMoney.Amount);
        }
    }
}
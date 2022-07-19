using Budgets.Domain.ValueObjects;
using NodaMoney;
using System.Collections.Generic;
using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class CategoryBuilder
    {
        public int Id { get; private set; }
        public int GroupCategoryId { get; private set; }
        public string Label  { get; private set; }
        public Dictionary<MonthYear, Money> MoneyAssigned  { get; private set; }
        public List<Transaction> TransactionsAssociated  { get; private set; }

        public CategoryBuilder()
        {
            Id = 0;
            GroupCategoryId = 0;
            MoneyAssigned = new Dictionary<MonthYear, Money>();
            TransactionsAssociated = new List<Transaction>();
            Label = "defaultLabel";
        }

        public CategoryBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public CategoryBuilder WithGroupCategoryId(int groupCategoryId)
        {
            this.GroupCategoryId = groupCategoryId;
            return this;
        }

        public CategoryBuilder WithLabel(string label)
        {
            this.Label = label;
            return this;
        }

        public CategoryBuilder WithMoneyAssigned(MonthYear monthYear, Money money)
        {
            if(MoneyAssigned.ContainsKey(monthYear))
                MoneyAssigned.Remove(monthYear);
            this.MoneyAssigned.Add(monthYear, money);
            return this;
        }

        public Category Build()
        {
            var category = new Category(Id, Label);
            foreach(var dict in MoneyAssigned)
            {
                category.AssignMoney(dict.Key, dict.Value);
            }

            category.AssociateTransaction(TransactionsAssociated.ToArray());
            return category;
        }
    }
}
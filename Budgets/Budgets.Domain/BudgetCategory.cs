using NodaMoney;
using System.Collections.Generic;

namespace Budgets.Domain
{
    public class BudgetCategory
    {
        protected BudgetCategory() { }

        public string Label { get; set; }
        public List<MoneyAssigned> MoneyAssigned { get; set; }

        public BudgetCategory(string label)
        {
            MoneyAssigned = new List<MoneyAssigned>();
            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategory label";
            Label = label;
        }

        public void AddMoney(params MoneyAssigned[] moneyAssigned)
        {
            MoneyAssigned.AddRange(moneyAssigned);
        }
    }
}
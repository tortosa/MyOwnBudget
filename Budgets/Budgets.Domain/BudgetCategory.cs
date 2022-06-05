using NodaMoney;

namespace Budgets.Domain
{
    public class BudgetCategory
    {
        protected BudgetCategory() { }

        public string Label { get; set; }
        public Money AssignedMoney { get; set; }         

        public BudgetCategory(string label, Money assignedMoney)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategory label";
            Label = label;
            this.AssignedMoney = assignedMoney;
        }
    }
}
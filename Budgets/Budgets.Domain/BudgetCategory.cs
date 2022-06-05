using NodaMoney;

namespace Budgets.Domain
{
    public class BudgetCategory
    {
        protected BudgetCategory() { }

        public string Label { get; set; }
        public BudgetCategoryGroup BudgetCategoryGroup { get; set; }
        public Money AssignedMoney { get; set; }         

        public BudgetCategory(string label, BudgetCategoryGroup budgetCategoryGroup, Money assignedMoney)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategory label";
            Label = label;
            this.BudgetCategoryGroup = budgetCategoryGroup;
            this.AssignedMoney = assignedMoney;
        }
    }
}
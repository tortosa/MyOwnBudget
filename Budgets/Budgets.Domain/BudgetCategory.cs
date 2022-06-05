namespace Budgets.Domain
{
    public class BudgetCategory
    {
        protected BudgetCategory() { }

        public string Label { get; set; }
        public BudgetCategoryGroup budgetCategoryGroup { get; set; }

        public BudgetCategory(string label, BudgetCategoryGroup budgetCategoryGroup)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategory label";
            Label = label;
            this.budgetCategoryGroup = budgetCategoryGroup;
        }
    }
}
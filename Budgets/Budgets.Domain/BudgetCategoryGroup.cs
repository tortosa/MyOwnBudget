namespace Budgets.Domain
{
    public class BudgetCategoryGroup
    {
        protected BudgetCategoryGroup() { }

        public string Label { get; set; }

        public BudgetCategoryGroup(string label)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default BudgetCategoryGroup label";
            Label = label;
        }
    }
}
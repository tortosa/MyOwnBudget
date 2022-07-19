namespace Budgets.Domain.Specifications.Model
{
    public class GroupCategoryModel
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string Label { get; set; }
    }
}
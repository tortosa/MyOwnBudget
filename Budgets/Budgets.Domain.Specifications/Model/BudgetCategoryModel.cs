namespace Budgets.Domain.Specifications.Model
{
    public class BudgetCategoryModel
    {
        public int Id { get; set; }
        public int GroupCategoryId { get; set; }
        public string Label { get; set; }
    }
}
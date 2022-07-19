namespace Budgets.Domain.Specifications.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int GroupCategoryId { get; set; }
        public string Label { get; set; }
    }
}
using System.Collections.Generic;

namespace Budgets.Domain.Specifications.Model
{
    public class BudgetModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string DateFormat { get; set; }
        public string Currency { get; set; }
    }
}
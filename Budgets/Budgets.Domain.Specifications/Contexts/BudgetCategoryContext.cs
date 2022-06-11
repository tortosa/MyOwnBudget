using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain.Specifications.Contexts
{
    public class BudgetCategoryContext
    {
        public BudgetCategoryContext()
        {
            BudgetCategories = Enumerable.Empty<BudgetCategoryBuilder>();
        }

        public IEnumerable<BudgetCategoryBuilder> BudgetCategories { get; set; }
    }
}
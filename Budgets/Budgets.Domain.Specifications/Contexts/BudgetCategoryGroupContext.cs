using Budgets.Tests.Common.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgets.Domain.Specifications.Contexts
{
    public class BudgetCategoryGroupContext
    {
        public BudgetCategoryGroupContext()
        {
            BudgetCategoryGroups = Enumerable.Empty<BudgetCategoryGroupBuilder>();
        }

        public IEnumerable<BudgetCategoryGroupBuilder> BudgetCategoryGroups { get; set; }
    }
}
using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain.Specifications.Contexts
{
    public class BudgetContext
    {
        public BudgetContext()
        {
            Budgets = Enumerable.Empty<BudgetBuilder>();
        }

        public IEnumerable<BudgetBuilder> Budgets { get; set; }
    }
}
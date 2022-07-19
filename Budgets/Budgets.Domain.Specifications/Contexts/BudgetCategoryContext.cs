using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain.Specifications.Contexts
{
    public class CategoryContext
    {
        public CategoryContext()
        {
            Categories = Enumerable.Empty<CategoryBuilder>();
        }

        public IEnumerable<CategoryBuilder> Categories { get; set; }
    }
}
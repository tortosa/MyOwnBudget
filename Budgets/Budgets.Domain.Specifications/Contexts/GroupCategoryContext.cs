using Budgets.Tests.Common.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgets.Domain.Specifications.Contexts
{
    public class GroupCategoryContext
    {
        public GroupCategoryContext()
        {
            GroupCategories = Enumerable.Empty<GroupCategoryBuilder>();
        }

        public IEnumerable<GroupCategoryBuilder> GroupCategories { get; set; }
    }
}
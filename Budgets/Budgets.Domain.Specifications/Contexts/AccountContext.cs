using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain.Specifications.Contexts
{
    public class AccountContext
    {
        public AccountContext()
        {
            Accounts = Enumerable.Empty<AccountBuilder>();
        }

        public IEnumerable<AccountBuilder> Accounts { get; set; }
    }
}
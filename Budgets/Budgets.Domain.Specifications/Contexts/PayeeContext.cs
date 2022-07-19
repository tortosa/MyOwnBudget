using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain.Specifications.Contexts
{
    public class PayeeContext
    {
        public PayeeContext()
        {
            Payees = Enumerable.Empty<PayeeBuilder>();
        }

        public IEnumerable<PayeeBuilder> Payees { get; set; }
    }
}
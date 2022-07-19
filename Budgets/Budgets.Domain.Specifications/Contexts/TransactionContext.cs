using Budgets.Tests.Common.Builders;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Domain.Specifications.Contexts
{
    public class TransactionContext
    {
        public TransactionContext()
        {
            Transactions = Enumerable.Empty<TransactionBuilder>();
        }

        public IEnumerable<TransactionBuilder> Transactions { get; set; }
    }
}
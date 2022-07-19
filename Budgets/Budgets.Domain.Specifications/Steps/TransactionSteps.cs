using Budgets.Domain.Specifications.Contexts;
using Budgets.Domain.Specifications.Model;
using Budgets.Domain.Specifications.Steps.Given;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Budgets.Domain.Specifications.Steps
{
    [Binding]
    public class TransactionSteps
    {
        private readonly TransactionContext transactionContext;

        public TransactionSteps(TransactionContext transactionContext)
        {
            this.transactionContext = transactionContext;
        }

        [Given(@"Transactions")]
        public void GivenTransactions(Table table)
        {
            var modelList = table.CreateSet<TransactionModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your transaction ids, they may be duplicated");

            transactionContext.Transactions = GivenBuilderFactory.GivenTransactions(modelList);
        }
    }
}
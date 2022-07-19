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
    public class PayeeSteps
    {
        private readonly PayeeContext PayeeContext;

        public PayeeSteps(PayeeContext budgetContext)
        {
            this.PayeeContext = budgetContext;
        }

        [Given(@"Payees")]
        public void GivenPayees(Table table)
        {
            var modelList = table.CreateSet<PayeeModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your account ids, they may be duplicated");

            PayeeContext.Payees = GivenBuilderFactory.GivenPayees(modelList);
        }
    }
}
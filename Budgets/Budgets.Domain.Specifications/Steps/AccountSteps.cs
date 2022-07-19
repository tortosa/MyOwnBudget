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
    public class AccountSteps
    {
        private readonly AccountContext accountContext;

        public AccountSteps(AccountContext budgetContext)
        {
            this.accountContext = budgetContext;
        }

        [Given(@"Accounts")]
        public void GivenAccounts(Table table)
        {
            var modelList = table.CreateSet<AccountModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your account ids, they may be duplicated");

            accountContext.Accounts = GivenBuilderFactory.GivenAccounts(modelList);
        }
    }
}
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
    public class BudgetSteps
    {
        private readonly BudgetContext budgetContext;

        public BudgetSteps(BudgetContext budgetContext)
        {
            this.budgetContext = budgetContext;
        }

        [Given(@"Budgets")]
        public void GivenBudgets(Table table)
        {
            var modelList = table.CreateSet<BudgetModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your budget ids, they may be duplicated");

            budgetContext.Budgets = GivenBuilderFactory.GivenBudgets(modelList);
        }

        [When(@"(.*) is actioned")]
        public void WhenBudgetIsActioned(string budgetLabel)
        {
            var test = budgetContext.Budgets.Where(x => x.Label.Equals(budgetLabel, System.StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            var budget = test.Build();
        }

    }
}
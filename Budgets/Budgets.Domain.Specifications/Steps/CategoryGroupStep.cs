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
    public class CategoryGroupStep
    {
        private readonly BudgetContext budgetContext;
        private readonly BudgetCategoryGroupContext categoryGroupContext;

        public CategoryGroupStep(BudgetContext budgetContext, BudgetCategoryGroupContext categoryGroupContext)
        {
            this.budgetContext = budgetContext;
            this.categoryGroupContext = categoryGroupContext;
        }

        [Given(@"CategoryGroup associated to budgets")]
        public void GivenCategoryGroup(Table table)
        {
            var modelList = table.CreateSet<BudgetCategoryGroupModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your category group ids, they may be duplicated");

            categoryGroupContext.BudgetCategoryGroups = GivenBuilderFactory.GivenCategoryGroup(modelList);

            foreach (var budgetBuilder in budgetContext.Budgets)
            {
                var groupsPerBudget = categoryGroupContext.BudgetCategoryGroups.Where(x =>x.BudgetId == budgetBuilder.Id).ToArray();
                budgetBuilder.WithBudgetCategoryGroups(groupsPerBudget);
            }
        }
    }
}
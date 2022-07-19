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
    public class GroupCategoryStep
    {
        private readonly BudgetContext budgetContext;
        private readonly GroupCategoryContext categoryGroupContext;

        public GroupCategoryStep(BudgetContext budgetContext, GroupCategoryContext categoryGroupContext)
        {
            this.budgetContext = budgetContext;
            this.categoryGroupContext = categoryGroupContext;
        }

        [Given(@"GroupCategory associated to budgets")]
        public void GivenGroupCategory(Table table)
        {
            var modelList = table.CreateSet<GroupCategoryModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your category group ids, they may be duplicated");

            categoryGroupContext.GroupCategories = GivenBuilderFactory.GivenGroupCategory(modelList);

            foreach (var budgetBuilder in budgetContext.Budgets)
            {
                var groupsPerBudget = categoryGroupContext.GroupCategories.Where(x =>x.BudgetId == budgetBuilder.Id).ToArray();
                budgetBuilder.WithGroupCategories(groupsPerBudget);
            }
        }
    }
}
using Budgets.Domain.Specifications.Contexts;
using Budgets.Domain.Specifications.Model;
using Budgets.Domain.Specifications.Steps.Given;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
                throw new Exception("Check your GroupCategory ids, they may be duplicated");

            categoryGroupContext.GroupCategories = GivenBuilderFactory.GivenGroupCategory(modelList);

            foreach (var budgetBuilder in budgetContext.Budgets)
            {
                var groupsPerBudget = categoryGroupContext.GroupCategories.Where(x =>x.BudgetId == budgetBuilder.Id).ToArray();
                budgetBuilder.WithGroupCategories(groupsPerBudget);
            }
        }
    }
}
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
    public class CategoryStep
    {
        private readonly GroupCategoryContext categoryGroupContext;
        private readonly BudgetCategoryContext categoryContext;

        public CategoryStep(BudgetCategoryContext categoryContext, GroupCategoryContext categoryGroupContext)
        {
            this.categoryContext = categoryContext;
            this.categoryGroupContext = categoryGroupContext;
        }

        [Given(@"Category associated to GroupCategory")]
        public void GivenCategory(Table table)
        {
            var modelList = table.CreateSet<BudgetCategoryModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your category ids, they may be duplicated");

            categoryContext.BudgetCategories = GivenBuilderFactory.GivenCategory(modelList);

            foreach (var categoryGroupBuilder in categoryGroupContext.GroupCategories)
            {
                var categoriesPerGroup = categoryContext.BudgetCategories.Where(x =>x.GroupCategoryId == categoryGroupBuilder.Id).ToArray();
                categoryGroupBuilder.WithBudgetCategories(categoriesPerGroup);
            }
        }
    }
}
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
        private readonly CategoryContext categoryContext;

        public CategoryStep(CategoryContext categoryContext, GroupCategoryContext categoryGroupContext)
        {
            this.categoryContext = categoryContext;
            this.categoryGroupContext = categoryGroupContext;
        }

        [Given(@"Category associated to GroupCategory")]
        public void GivenCategory(Table table)
        {
            var modelList = table.CreateSet<CategoryModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your category ids, they may be duplicated");

            categoryContext.Categories = GivenBuilderFactory.GivenCategory(modelList);

            foreach (var categoryGroupBuilder in categoryGroupContext.GroupCategories)
            {
                var categoriesPerGroup = categoryContext.Categories.Where(x =>x.GroupCategoryId == categoryGroupBuilder.Id).ToArray();
                categoryGroupBuilder.WithCategories(categoriesPerGroup);
            }
        }
    }
}
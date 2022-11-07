using Budgets.Domain.Aggregates;
using Budgets.Domain.Specifications.Contexts;
using Budgets.Domain.Specifications.Model;
using Budgets.Domain.Specifications.Steps.Given;
using Budgets.Domain.ValueObjects;
using Budgets.Tests.Common.Builders;
using NodaMoney;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Budgets.Domain.Specifications.Steps
{
    [Binding]
    public class BudgetSteps
    {
        private Budget budgetActioned;

        private readonly AccountContext accountContext;
        private readonly BudgetContext budgetContext;
        private readonly PayeeContext payeeContext;

        public BudgetSteps(AccountContext accountContext, BudgetContext budgetContext, PayeeContext payeeContext)
        {
            this.accountContext = accountContext;
            this.budgetContext = budgetContext;
            this.payeeContext = payeeContext;
        }

        [Given(@"Budgets")]
        public void GivenBudgets(Table table)
        {
            var modelList = table.CreateSet<BudgetModel>().ToList();
            if (modelList.Select(model => model.Id).Count() != modelList.Count)
                Assert.True(false, "Check your budget ids, they may be duplicated");

            budgetContext.Budgets = GivenBuilderFactory.GivenBudgets(modelList);
        }

        [When(@"Transaction is added to (.*) on (.*) to Account (.*), Payee (.*), Category (.*) with and amount of (.*) - (.*)")]
        public void TransactionIsAdded(string budgetLabel, string date, string accountLabel, string payeeLabel, string categoryLabel, decimal amount, string currency)
        {
            var isSameBudget = budgetActioned != null && budgetActioned.Equals(budgetActioned);
            if (!isSameBudget)
                budgetActioned = budgetContext.Budgets.Where(x => x.Label.Equals(budgetLabel, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault().Build();
            var account = accountContext.Accounts.Where(x => x.Label.Equals(accountLabel, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault().Build();
            var payee = payeeContext.Payees.Where(x => x.Label.Equals(payeeLabel, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault().Build();
            var category = budgetActioned.GroupCategories.Select(x => x.Categories.SingleOrDefault(c => c.Label.Equals(categoryLabel, StringComparison.InvariantCultureIgnoreCase))).Where(x => x != null).Single();
            var transactionDate = DateTime.ParseExact(date, budgetActioned.DateFormat, null);

            var transaction = new TransactionBuilder()
                .WithAccount(account)
                .WithPayee(payee)
                .WithDate(transactionDate)
                .WithCategory(category)
                .WithMoney(new Money(amount, Currency.FromCode(currency)))
                .Build();

            budgetActioned.AddTransaction(transaction);
        }

        [When(@"Assign an amount of (.*) - (.*) at (.*)/(.*) to Category (.*)")]
        public void AssignMoneyToCategory(decimal amount, string currency, string month, int year, string categoryLabel)
        {
            var category = budgetActioned.GroupCategories.Select(x => x.Categories.SingleOrDefault(c => c.Label.Equals(categoryLabel, StringComparison.InvariantCultureIgnoreCase))).Where(x => x != null).Single();
            Month monthEnum = (Month)Enum.Parse(typeof(Month), month);
            category.AssignMoney(new MonthYear(monthEnum, year), new Money(amount, Currency.FromCode(currency)));
        }

        [Then(@"GroupCategory with label (.*) should have (.*) assigned")]
        public void ThenGroupCategoryShouldHaveExpectedMoneyAssigned(string label, decimal expectedAmount)
        {
            var groupCategory = budgetActioned.GroupCategories.Where(x => x.Label.Equals(label, StringComparison.InvariantCultureIgnoreCase)).Single();

            Assert.Equal(expectedAmount, groupCategory.AssignedMoney.Amount);
        }

        [Then(@"GroupCategory with label (.*) should have (.*) available at (.*)/(.*)")]
        public void ThenGroupCategoryShouldHaveExpectedMoneyAvailable(string label, decimal expectedAmount, string month, int year)
        {
            var groupCategory = budgetActioned.GroupCategories.Where(x => x.Label.Equals(label, StringComparison.InvariantCultureIgnoreCase)).Single();
            Month monthEnum = (Month)Enum.Parse(typeof(Month), month);

            Assert.Equal(expectedAmount, groupCategory.GetAvailableMoneyAt(new MonthYear(monthEnum, year)).Amount);
        }

        [Then(@"Category with label (.*) should have (.*) assigned at (.*)/(.*)")]
        public void ThenCategoryShouldHaveExpectedMoneyAssigned(string label, decimal expectedAmount, string month, int year)
        {
            var category = budgetActioned.GroupCategories.Select(x => x.Categories.SingleOrDefault(c => c.Label.Equals(label, StringComparison.InvariantCultureIgnoreCase))).Where(x => x != null).Single();
            Month monthEnum = (Month)Enum.Parse(typeof(Month), month);

            Assert.Equal(expectedAmount, category.GetAssignedMoneyAt(new MonthYear(monthEnum, year)).Amount);
        }

        [Then(@"Category with label (.*) should have (.*) available at (.*)/(.*)")]
        public void ThenCategoryShouldHaveExpectedMoneyAvailable(string label, decimal expectedAmount, string month, int year)
        {
            var category = budgetActioned.GroupCategories.Select(x => x.Categories.SingleOrDefault(c => c.Label.Equals(label, StringComparison.InvariantCultureIgnoreCase))).Where(x => x != null).Single();
            Month monthEnum = (Month)Enum.Parse(typeof(Month), month);

            Assert.Equal(expectedAmount, category.GetAvailableMoneyAt(new MonthYear(monthEnum, year)).Amount);
        }
    }
}
namespace Budgets.Domain.UnitTests.Builders
{
    public class BudgetBuilder
    {
        private string label;
        private string currencyCode;
        private string dateFormat;

        public BudgetBuilder()
        {
            label = "defaultLabel";
            currencyCode = "EUR";
        }

        public BudgetBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public BudgetBuilder WithCurrencyCode(string currencyCode)
        {
            this.currencyCode = currencyCode;
            return this;
        }

        public BudgetBuilder WithDateFormat(string dateFormat)
        {
            this.dateFormat = dateFormat;
            return this;
        }

        public Budget Build()
        {
            var budget = new Budget(label, currencyCode, dateFormat);
            return budget;
        }
    }
}
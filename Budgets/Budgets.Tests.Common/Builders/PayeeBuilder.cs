using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class PayeeBuilder
    {
        private string label;

        public PayeeBuilder()
        {
            label = "defaultLabel";
        }

        public PayeeBuilder WithLabel(string label)
        {
            this.label = label;
            return this;
        }

        public Payee Build()
        {
            var payee = new Payee(label);
            return payee;
        }
    }
}
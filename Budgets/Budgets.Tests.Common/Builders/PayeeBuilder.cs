using Budgets.Domain;

namespace Budgets.Tests.Common.Builders
{
    public class PayeeBuilder
    {
        public int Id { get; private set; }
        public string Label { get; private set; }

        public PayeeBuilder()
        {
            Label = "defaultLabel";
        }

        public PayeeBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public PayeeBuilder WithLabel(string label)
        {
            this.Label = label;
            return this;
        }

        public Payee Build()
        {
            var payee = new Payee(Id, Label);
            return payee;
        }
    }
}
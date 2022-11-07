namespace Budgets.Domain.Aggregates
{
    public class Payee
    {
        protected Payee() { }

        public int Id { get; }
        public string Label { get; }

        public Payee(int id, string label)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default Payee label";
            Label = label;
            Id = id;
        }
    }
}
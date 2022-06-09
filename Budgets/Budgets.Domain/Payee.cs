namespace Budgets.Domain
{
    public class Payee
    {
        protected Payee() { }

        public string Label { get; }

        public Payee(string label)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default Payee label";
            Label = label;
        }
    }
}
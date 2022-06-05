namespace Budgets.Domain
{
    public class Payee
    {
        protected Payee() { }

        public string Label { get; set; }

        public Payee(string label)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default Payee label";
            Label = label;
        }
    }
}
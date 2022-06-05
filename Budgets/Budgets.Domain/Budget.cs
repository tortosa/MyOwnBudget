using NodaMoney;

namespace Budgets.Domain
{
    public class Budget
    {
        protected Budget() { }

        public string Label { get; set; }

        public string DateFormat { get; set; }

        public Currency Currency;

        public Budget(string label, string currencyCode, string dateFormat)
        {
            if (string.IsNullOrEmpty(label))
                label = "Default account label";
            Label = label;
            Currency = Currency.FromCode(currencyCode);
            DateFormat = dateFormat;
        }
    }
}
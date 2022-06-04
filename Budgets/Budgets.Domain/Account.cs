using System;

namespace Budgets.Domain
{
    public class Account
    {
        public string Label { get; set; }
        public Account(string label)
        {
            Label = label;
        }
    }
}
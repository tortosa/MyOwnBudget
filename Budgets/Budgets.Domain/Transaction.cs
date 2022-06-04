using System;

namespace Budgets.Domain
{
    public class Transaction
    {
        public double Value { get; set; }
        public Transaction(double value)
        {
            Value = value;
        }
    }
}
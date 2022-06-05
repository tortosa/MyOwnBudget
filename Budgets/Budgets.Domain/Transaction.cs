using System;

namespace Budgets.Domain
{
    public class Transaction
    {
        protected Transaction() { }

        public double Value { get; set; }
        public DateTime Date { get; set; }

        public Transaction(double value, DateTime date)
        {
            Value = value;
            Date = date;
        }
    }
}
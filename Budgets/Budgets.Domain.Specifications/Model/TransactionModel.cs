namespace Budgets.Domain.Specifications.Model
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal MoneyAmount { get; set; }
        public string MoneyCurrency { get; set; }
        public string Date { get; set; }
        public int PayeeId { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
    }
}
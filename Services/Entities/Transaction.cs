namespace BudgetApp.Services.Entities;

public abstract class Transaction(decimal amount, string source, DateTime? date = null)
{
    public decimal Amount { get; set; } = amount;
    public string Source { get; set; } = source;
    public DateTime? Date { get; set; } = date;
}
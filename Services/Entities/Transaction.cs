namespace BudgetApp.Services.Entities;

public class Transaction(decimal amount, string source, Category category, DateTime? date = null, string? type = null)
{
    public decimal Amount { get; set; } = amount;
    public string Source { get; set; } = source;
    public string? Type { get; set; } = type;
    public Category Category { get; set; } = category;
    public DateTime? Date { get; set; } = date;
}

public class TransactionComparer : IEqualityComparer<Transaction>
{
    public bool Equals(Transaction? x, Transaction? y)
    {
        if (x == null && y == null) return true;
        if (x == null || y == null) return false;

        if (x.Amount != y.Amount) return false;
        if (x.Source != y.Source) return false;
        if (x.Category.Name != y.Category.Name) return false;
        if (x.Date != y.Date) return false;

        return true;
    }

    public int GetHashCode(Transaction obj)
    {
        return obj.Amount.GetHashCode()
            + obj.Source.GetHashCode()
            + obj.Category.Name.GetHashCode()
            + obj.Date?.GetHashCode() ?? 0;
    }
}
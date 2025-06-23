namespace BudgetApp.Services.Entities;

// ReSharper disable once ClassNeverInstantiated.Global
public class Transaction(decimal amount, string source, string? type = null, DateTime? date = null)
{
    public decimal Amount { get; set; } = amount;
    public string Source { get; set; } = source;
    public string? Type { get; set; } = type;
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
        if (x.Type != y.Type) return false;
        if (x.Date != y.Date) return false;

        return true;
    }

    public int GetHashCode(Transaction obj)
    {
        return obj.Amount.GetHashCode()
            + obj.Source.GetHashCode()
            + obj.Type?.GetHashCode() ?? 0
            + obj.Date?.GetHashCode() ?? 0;
    }
}
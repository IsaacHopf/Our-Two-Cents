namespace BudgetApp.Services.Entities;

public class Expense(decimal amount, string source, string type, DateTime? date = null) 
    : Transaction(amount, source, date)
{
    public string Type { get; set; } = type;
}

public class ExpenseComparer : IEqualityComparer<Expense>
{
    public bool Equals(Expense? x, Expense? y)
    {
        if (x is null && y is null) return true;
        if (x is null || y is null) return false;

        if (x.Amount != y.Amount) return false;
        if (x.Source != y.Source) return false;
        if (x.Type != y.Type) return false;
        if (x.Date != y.Date) return false;

        return true;
    }

    public int GetHashCode(Expense obj)
    {
        return obj.Amount.GetHashCode() + obj.Source.GetHashCode() + obj.Type.GetHashCode() + obj.Date.GetHashCode();
    }
}

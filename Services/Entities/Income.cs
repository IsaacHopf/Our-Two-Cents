namespace BudgetApp.Services.Entities;

public class Income(decimal amount, string source, DateTime? date = null) : Transaction(amount, source, date)
{
}

public class IncomeComparer : IEqualityComparer<Income>
{
    public bool Equals(Income? x, Income? y)
    {
        if (x is null && y is null) return true;
        if (x is null || y is null) return false;

        if (x.Amount != y.Amount) return false;
        if (x.Source != y.Source) return false;
        if (x.Date != y.Date) return false;

        return true;
    }

    public int GetHashCode(Income obj)
    {
        return obj.Amount.GetHashCode() + obj.Source.GetHashCode() + obj.Date.GetHashCode();
    }
}
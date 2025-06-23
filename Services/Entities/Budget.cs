using System.Text.Json.Serialization;

namespace BudgetApp.Services.Entities;

public class Budget(int month, int year)
{
    [JsonPropertyName("id")] 
    public string Name { get; } = $"{month.ToMonthName()} {year}";
    public int Month { get; } =  month;
    public int Year { get; } = year;
    public List<Transaction> Incomes { get; set; } = [];
    public decimal TotalIncome => Incomes.Sum(i => i.Amount);
    public List<Transaction> Expenses { get; set; } = [];
    public decimal TotalExpenses => Expenses.Sum(e => e.Amount);
    public decimal Net => TotalIncome - TotalExpenses;
    public string? Notes { get; set; }
}

public static class BudgetExtensions
{
    public static IEnumerable<Budget> OrderByDate(this IEnumerable<Budget> budgets) =>
        budgets.OrderBy(x => x.Year).ThenBy(x => x.Month);

    public static IEnumerable<Budget> OrderByDateDescending(this IEnumerable<Budget> budgets) =>
        budgets.OrderByDescending(x => x.Year).ThenByDescending(x => x.Month);
}
using System.Globalization;
using System.Text.Json.Serialization;

namespace BudgetApp.Services.Entities;

public class Budget(int month, int year)
{
    [JsonPropertyName("id")]
    public string Name { get; } = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}";
    
    public string Discriminator { get; } = "Budget";
    public int Month { get; } =  month;
    public int Year { get; } = year;
    public List<Transaction> Incomes { get; set; } = [];
    public decimal TotalIncome => Incomes.Sum(i => i.Amount);
    public List<Transaction> Expenses { get; set; } = [];
    public decimal TotalExpenses => Expenses.Sum(e => e.Amount);
    public decimal Net => TotalIncome - TotalExpenses;
    public string? Notes { get; set; }
    
    public override string ToString() => Name;
}
namespace BudgetApp.Services.Entities;

public class Category(string name, string color = "#f4c2c2", Guid id = default)
{
    public Guid Id { get; set; } = id == default ? Guid.NewGuid() : id;
    public string Name { get; set; } = name;
    public string Color { get; set; } = color;
}
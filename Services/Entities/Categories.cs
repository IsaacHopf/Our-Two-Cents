namespace BudgetApp.Services.Entities;

public class Categories
{
    public const string Id = "Categories";
    public const string Discriminator = "Categories";
    public List<Category> Items { get; init; } = [];
}
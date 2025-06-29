using System.Text.Json.Serialization;

namespace BudgetApp.Services.Entities;

public class Categories
{
    /// <remarks>Must be property or else Cosmos won't work.</remarks>
    public string Id { get; } = "Categories";
    public string Discriminator { get; } = "Categories";
    public List<Category> Items { get; init; } = [];
}
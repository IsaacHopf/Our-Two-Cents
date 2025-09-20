namespace BudgetApp.Services.Entities;

public class Reminders
{
    /// <remarks>Must be property or else Cosmos won't work.</remarks>
    public string Id { get; } = "Reminders";
    public string Discriminator { get; } = "Reminders";
    public List<string> Items { get; init; } = [];
}
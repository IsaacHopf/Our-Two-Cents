namespace BudgetApp.Services.Entities;

public class FixedBudget() : Budget(1, 1)
{
    public new const string Name = "January 1";
    /// <remarks>Must be property or else it will be set to "Budget".</remarks>
    public new string Discriminator { get; } = "FixedBudget";
}
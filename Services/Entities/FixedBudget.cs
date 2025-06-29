namespace BudgetApp.Services.Entities;

public class FixedBudget() : Budget(1, 1)
{
    public new const string Name = "January 1";
    public new const string Discriminator = "FixedBudget";
}
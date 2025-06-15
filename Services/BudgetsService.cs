using BudgetApp.Services.Entities;
using Microsoft.Azure.Cosmos;

namespace BudgetApp.Services;

public class BudgetsService(CosmosClient cosmosClient)
{
    private const string DatabaseName = "BudgetApp";
    private const string ContainerName = "Budgets";
    private const string FixedBudgetName = "January 1";

    private readonly Container _container = cosmosClient.GetContainer(DatabaseName, ContainerName);

    public async Task<Budget> GetBudgetAsync(string budgetName) =>
        await _container.ReadItemAsync<Budget>(budgetName, new PartitionKey(budgetName));

    public async Task<Budget> GetFixedBudget() => await GetBudgetAsync(FixedBudgetName);

    public async Task<IEnumerable<Budget>> GetBudgetsAsync() =>
        await _container.GetItemLinqQueryable<Budget>()
            .Where(x => x.Name != FixedBudgetName).ToEnumerableAsync();

    public async Task<IEnumerable<Budget>> GetBudgetsAsync(int year) =>
        await _container.GetItemLinqQueryable<Budget>()
            .Where(x => x.Name != FixedBudgetName).Where(x => x.Year == year).ToEnumerableAsync();

    public async Task<Budget> UpsertBudgetAsync(Budget budget) =>
        await _container.UpsertItemAsync(budget, new PartitionKey(budget.Name));

    public async Task DeleteBudgetAsync(string budgetName) =>
        await _container.DeleteItemAsync<Budget>(budgetName, new PartitionKey(budgetName));

    public async Task DeleteBudgetAsync(Budget budget) => await DeleteBudgetAsync(budget.Name);
}
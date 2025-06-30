using BudgetApp.Services.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace BudgetApp.Services.Repositories;

public class BudgetsRepository(CosmosClient cosmosClient, IConfiguration config) : BaseRepository(cosmosClient, config)
{
    public async Task<Budget> ReadAsync(string name) => await ReadAsync<Budget>(name);
    public IQueryable<Budget> Query() => Query<Budget>().Where(x => x.Discriminator == "Budget");
    public async Task UpsertAsync(Budget budget) => await UpsertAsync(budget.Name, budget);
    public async Task DeleteAsync(string name) => await DeleteAsync<Budget>(name);
}
using BudgetApp.Services.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace BudgetApp.Services.Repositories;

public class FixedBudgetRepository(CosmosClient cosmosClient, IConfiguration config)
    : BaseRepository(cosmosClient, config)
{
    public async Task<FixedBudget> GetAsync() => await GetAsync<FixedBudget>(FixedBudget.Name);
    public async Task UpsertAsync(FixedBudget fixedBudget) => await UpsertAsync(FixedBudget.Name, fixedBudget);
}
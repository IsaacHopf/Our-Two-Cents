using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace BudgetApp.Services.Repositories;

public abstract class BaseRepository(CosmosClient cosmosClient, IConfiguration config)
{
    private readonly Container _container =
        cosmosClient.GetContainer(config["DatabaseName"], config["BudgetsContainerName"]);
    
    protected async Task<T> GetAsync<T>(string id) => await _container.ReadItemAsync<T>(id, new PartitionKey(id));
    protected IQueryable<T> Query<T>() => _container.GetItemLinqQueryable<T>();
    protected async Task UpsertAsync<T>(string id, T item) => await _container.UpsertItemAsync(item, new PartitionKey(id));
    protected async Task DeleteAsync<T>(string id) => await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
}
using BudgetApp.Services.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace BudgetApp.Services.Repositories;

public class CategoriesRepository(CosmosClient cosmosClient, IConfiguration config)
    : BaseRepository(cosmosClient, config)
{
    public async Task<List<Category>> ReadAsync()
    {
        try
        {
            return (await ReadAsync<Categories>("Categories")).Items;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return [];
        }
    }

    public async Task UpsertAsync(List<Category> categories)
    {
        if (categories.Count == 0) return;
        await UpsertAsync("Categories", new Categories { Items = categories });
    }
}
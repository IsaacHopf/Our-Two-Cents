using Microsoft.Azure.Cosmos.Linq;

namespace BudgetApp.Services.Repositories;

public static class CosmosExtensions
{
    public static async Task<IEnumerable<T>> ToEnumerableAsync<T>(this IQueryable<T> queryable)
    {
        var feed = queryable.ToFeedIterator<T>();

        List<T> items = [];
        while (feed.HasMoreResults) items.AddRange(await feed.ReadNextAsync());

        return items;
    }

    public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> queryable) =>
        (await queryable.ToEnumerableAsync()).ToList();

    public static async Task<T[]> ToArrayAsync<T>(this IQueryable<T> queryable) =>
        (await queryable.ToEnumerableAsync()).ToArray();
}
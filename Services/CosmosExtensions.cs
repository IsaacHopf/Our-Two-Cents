using Microsoft.Azure.Cosmos.Linq;

namespace BudgetApp.Services;

public static class CosmosExtensions
{
    public static async Task<IEnumerable<T>> ToEnumerableAsync<T>(this IQueryable<T> queryable)
    {
        var feed = queryable.ToFeedIterator<T>();

        List<T> items = [];
        while (feed.HasMoreResults) items.AddRange(await feed.ReadNextAsync());

        return items;
    }
}
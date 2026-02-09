namespace BudgetApp.Services;

public static class AverageExtensions
{
    /// <summary>
    /// Computes the average of a sequence after projecting each element to a decimal value,
    /// with an option to exclude statistical outliers using the Interquartile Range (IQR) method.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the input sequence.</typeparam>
    /// <param name="source">The sequence of input elements.</param>
    /// <param name="selector">A projection function that selects the decimal value from each element.</param>
    /// <param name="excludeOutliers">
    /// If true, removes values outside the IQR-based Tukey fences before averaging.
    /// If false, computes the average of all projected values.
    /// </param>
    /// <returns>The arithmetic mean of the selected values, optionally excluding outliers.</returns>

    public static decimal Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, bool excludeOutliers = false)
    {
        var sortedNumbers = source.Select(selector).OrderBy(x => x).ToList();

        if (!excludeOutliers || sortedNumbers.Count < 4) return sortedNumbers.Average();
        
        var q1 = CalculatePercentile(sortedNumbers, 0.25m); 
        var q3 = CalculatePercentile(sortedNumbers, 0.75m);
        var iqr = q3 - q1;
        var lowerFence = q1 - 1.5m * iqr; 
        var upperFence = q3 + 1.5m * iqr; 
        
        var sortedNumbersExcludingOutliers = sortedNumbers.Where(v => v >= lowerFence && v <= upperFence);
        
        return sortedNumbersExcludingOutliers.Average();
    }

    private static decimal CalculatePercentile(List<decimal> sortedNumbers, decimal percentile)
    {
        var n = sortedNumbers.Count;
        var index = (n - 1) * percentile;
        
        var lower = (int)index;
        var upper = lower + 1;
        
        if (upper >= n) return sortedNumbers[lower];
        
        var fraction = index - lower;
        return sortedNumbers[lower] + (sortedNumbers[upper] - sortedNumbers[lower]) * fraction;
    }
}
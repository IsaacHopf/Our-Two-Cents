using System.Globalization;

namespace BudgetApp.Services;

public static class DateTimeExtensions
{
    public static string ToMonthName(this DateTime dateTime) =>
        dateTime.ToString("MMMM");
    
    public static string ToMonthName(this int month) =>
        CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
    
    public static string ToMonthAbbreviation(this DateTime dateTime) =>
        dateTime.ToString("MMM");
    
    public static string ToMonthAbbreviation(this int month) =>
        CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
}
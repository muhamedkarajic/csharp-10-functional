﻿namespace Models;

public static class DateTimeExtensions
{
    public static IEnumerable<Month> GetYearMonths(this DateTime time) =>
        time.Year.GetYearMonths();
    
    public static IEnumerable<Month> GetDecadeMonths(this DateTime time) =>
        Enumerable.Range(time.Year.ToDecadeBeginning(), 10).SelectMany(GetYearMonths);
    
    private static int ToDecadeBeginning(this int year) => year / 10 * 10 + 1;
    
    private static IEnumerable<Month> GetYearMonths(this int year) =>
        Enumerable.Range(1, 12).Select(month => new Month(year, month));
}

﻿namespace Models;

public static class DateTimeExtensions
{
    public static IEnumerable<(int year, int month)> GetYearMonths(this DateTime time) =>
        Enumerable.Range(1, 12).Select(month => (time.Year, month));
}

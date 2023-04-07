namespace Models;

public record struct Year(int Number)
{
    public Month GetMonth(int ordinal) =>
        ordinal >= 1 && ordinal <= 12 ? new(this, ordinal)
        : throw new ArgumentException(nameof(ordinal));
    
    public IEnumerable<Month> Months =>
        this.GetMonths(this);
    
    private IEnumerable<Month> GetMonths(Year year) =>
        Enumerable.Range(1, 12).Select(ordinal => new Month(year, ordinal));
}

namespace Models.Types.Common;

public abstract record Measure(string Unit);

public record DiscreteMeasure(string Unit, uint Value) : Measure(Unit);
public record ContinuousMeasure(string Unit, decimal Value) : Measure(Unit);

public static class MeasureExtensions
{
    public static Measure AsDiscriminatedUnion(this Measure m) =>
        m switch
        {
            DiscreteMeasure or ContinuousMeasure => m,
            _ => throw new InvalidOperationException(
                    $"Not defined for object of type {m?.GetType().Name ?? "<null>"}")
        };
    
    public static TResult MapAny<TResult>(this Measure m,
        Func<DiscreteMeasure, TResult> discrete,
        Func<ContinuousMeasure, TResult> continuous) =>
        m.AsDiscriminatedUnion() switch
        {
            DiscreteMeasure d => discrete(d),
            ContinuousMeasure c => continuous(c),
            _ => default!
        };
}
namespace Models.Common;

using Models.Types.Common;

public static class MeasureTransforms
{
    public static (Measure a, Measure b) SplitInHalves(this Measure m) =>
        m switch
        {
            DiscreteMeasure d =>
                (d with { Value = (d.Value + 1) / 2}, d with { Value = d.Value / 2 }),
            ContinuousMeasure c when c with { Value = c.Value / 2 } is Measure half =>
                (half, half),
            _ => throw new InvalidOperationException(
                    $"Not defined for object of type {m?.GetType().Name ?? "<null>"}")
        };
}
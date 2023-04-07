using Models.Types.Components;
using Models.Types.Media;
using Models.Common;
using SkiaSharp;

namespace Models.Media;

public static class BarcodeGeneration
{
    public static FileContent ToCode39(this StockKeepingUnit sku, int barHeight) =>
        sku.Value.ToCode39Bars().ToCode39Bitmap(barHeight).ToPng();
    
    private static SKBitmap ToCode39Bitmap(this IEnumerable<int> bars, int barHeight) =>
        new(10, 10);
}

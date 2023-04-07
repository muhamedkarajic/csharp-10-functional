using Models.Types.Components;
using Models.Types.Media;

namespace Models.Media;

public static class BarcodeGeneration
{
    public static FileContent ToCode39(this StockKeepingUnit sku, int barHeight) =>
        new(Array.Empty<byte>(), string.Empty);
}
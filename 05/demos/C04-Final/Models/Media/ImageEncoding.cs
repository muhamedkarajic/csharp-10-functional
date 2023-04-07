using Models.Types.Media;
using SkiaSharp;

namespace Models.Media;

internal static class ImageEncoding
{
    public static FileContent ToPng(this SKBitmap bitmap) =>
        new(Array.Empty<byte>(), string.Empty);
}

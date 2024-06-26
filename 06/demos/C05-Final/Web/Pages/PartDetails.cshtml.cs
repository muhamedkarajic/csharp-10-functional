﻿using System.Linq;
using Application.Persistence;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Types.Components;
using Models.Types.Media;
using Models.Media;
using Models.Media.Types;

namespace Web.Pages;

public class PartDetailsModel : PageModel
{
    IReadOnlyRepository<Part> Parts { get; }

    public PartDetailsModel(IReadOnlyRepository<Part> parts)
    {
        this.Parts = parts;
    }

    public Part Part { get; set; } = null!;
    public FileContent BarcodeImage { get; set; } = null!;

    public void OnGet(Guid id)
    {
        this.Part = this.Parts.Find(id);
        this.BarcodeImage = this.GenerateBarcode(this.Part.Sku);

        var skus = Enumerable.Empty<StockKeepingUnit>();
        var f = Code39Generator.ToCode39.Apply(this.Margins, this.Style);
        var barcodes = skus.Select(f.Invoke);

        Func<StockKeepingUnit, FileContent> func = x => f(x);
        BarcodeGenerator g = x => func(x);
    }

    private BarcodeGenerator GenerateBarcode =>
        Code39Generator.ToCode39.Apply(this.Margins, this.Style);

    private BarcodeMargins Margins => new(
        Horizontal: 20, Vertical: 10, BarHeight: 200);
    
    private Code39Style Style => new(
        ThinBarWidth: 4, ThickBarWidth: 10, GapWidth: 6, Padding: 6, Antialias: false);
}

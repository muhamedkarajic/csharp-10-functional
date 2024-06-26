﻿using Application.Persistence;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Types.Components;
using Models.Media.Types;
using Models.Media;
using Web.Configuration;

namespace Web.Pages;

public class IndexModel : PageModel
{
    IReadOnlyRepository<Part> Parts { get; }

    public IndexModel(
        IReadOnlyRepository<Part> parts, BarcodeGeneratorFactory barcodeGenerators)
    {
        this.Parts = parts;
        this.BarcodeGenerator = barcodeGenerators.Inline;
    }

    public IEnumerable<Part> AllParts { get; set; } = Enumerable.Empty<Part>();
    public BarcodeGenerator BarcodeGenerator { get; }

    public void OnGet()
    {
        this.AllParts = this.Parts.GetAll().ToList();
    }
}

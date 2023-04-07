using Models.Types.Components;
using Models.Types.Common;

Part bc547 = new(Guid.NewGuid(), "Transistor BC547", new StockKeepingUnit("ELTRBC547"));
Option<Part> a = new Some<Part>(bc547);
Option<Part> b = new None<Part>();

Report(a, b);

Report(
    a.Map(part => part with { Name = "BC547" }),
    b.Map(part => part with { Name = "BC547" })
);

void Report(params object[] items)
{
    foreach (object item in items) Console.WriteLine(item);
    Console.WriteLine(new string('-', 80));
}
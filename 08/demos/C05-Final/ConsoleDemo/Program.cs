using Models.Types.Components;
using Models.Types.Common;

Part bc547 = new(Guid.NewGuid(), "Transistor BC547", new StockKeepingUnit("ELTRBC547"));
Option<Part> a = bc547;
Option<Part> b = None.Value;

Report(a, b);

bool Contains(string s, string target) =>
    s.Contains(target, StringComparison.OrdinalIgnoreCase);
string Remove(string s, string target) =>
    s.Replace(target, "", StringComparison.OrdinalIgnoreCase).Trim();

Report(
    a.Filter(part => Contains(part.Name, "resistor"))
        .Map(part => part with { Name = Remove(part.Name, "resistor") })
        .Map(part => part.Name)
        .Reduce("No resistance here, sir!"),

    a.Filter(part => Contains(part.Name, "transistor"))
        .Map(part => Remove(part.Name, "transistor"))
        .Reduce("Nothing to see here"),

    b.Filter(part => Contains(part.Name, "transistor"))
        .Map(part => Remove(part.Name, "transistor"))
        .Reduce("No, nothing yet, come back tomorrow")
);

void Report(params object[] items)
{
    foreach (object item in items) Console.WriteLine(item);
    Console.WriteLine(new string('-', 80));
}
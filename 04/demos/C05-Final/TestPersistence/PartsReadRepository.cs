namespace TestPersistence;

using Models.Types.Components;
using Application.Persistence;
using System.Collections.Generic;

public class PartsReadRepository : IReadOnlyRepository<Part>
{
    // Specification of materials for the traffic light DIY project
    // Source: https://www.instructables.com/Traffic-Light-Project/
    public IEnumerable<Part> GetAll() => new[]
    {
        new Part("Transistor BC547", new StockKeepingUnit("ELTRBC547")),
        new Part("Resistor 1K", new StockKeepingUnit("ELRS1K")),
        new Part("Resistor 100K", new StockKeepingUnit("ELRS100K")),
        new Part("Resistor 33K", new StockKeepingUnit("ELRS33K")),
        new Part("LED Red 3V", new StockKeepingUnit("ELLD3VRED")),
        new Part("LED Yellow 3V", new StockKeepingUnit("ELLD3VYELLOW")),
        new Part("LED Green 3V", new StockKeepingUnit("ELLD3VGREEN")),
        new Part("Capacitor 470uF 25V", new StockKeepingUnit("ELCP470UF25V")),
        new Part("Capacitor 100uF 25V", new StockKeepingUnit("ELCP100UF25V")),
        new Part("Battery 9V", new StockKeepingUnit("BT9V")),
        new Part("Battery clipper Type A", new StockKeepingUnit("BTCLA")),
    };
}
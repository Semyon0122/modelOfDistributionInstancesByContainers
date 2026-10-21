namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public readonly record struct StockKeepingUnitIdentifier
{
    private static long _nextId;

    public long Id { get; }

    public StockKeepingUnitIdentifier()
    {
        Id = _nextId++;
    }
}
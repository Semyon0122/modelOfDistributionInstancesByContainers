namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public record StockKeepingUnitIdentifier
{
    private static long _nextId;

    public long Id { get; } = _nextId++;
}
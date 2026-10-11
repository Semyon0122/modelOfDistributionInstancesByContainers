namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public record TareIdentifier
{
    private static long _nextId;

    public long Id { get; } = _nextId++;
}
namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public readonly record struct ItemIdentifier
{
    private static long _nextId;

    public long Id { get; }

    public ItemIdentifier()
    {
        Id = _nextId++;
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public readonly record struct TareIdentifier
{
    private static long _nextId;

    public long Id { get; }

    public TareIdentifier()
    {
        Id = _nextId++;
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public readonly record struct GroupIdentifier
{
    public long Id { get; }

    public GroupIdentifier(long id)
    {
        Id = id;
    }
}
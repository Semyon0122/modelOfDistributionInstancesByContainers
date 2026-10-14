namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public record GroupIdentifier
{
    public long Id { get; }

    public GroupIdentifier(long id)
    {
        Id = id;
    }
}
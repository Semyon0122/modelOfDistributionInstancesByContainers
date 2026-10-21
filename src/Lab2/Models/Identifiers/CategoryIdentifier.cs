namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

public readonly record struct CategoryIdentifier
{
    public long Id { get; }

    public CategoryIdentifier(long id)
    {
        Id = id;
    }
}
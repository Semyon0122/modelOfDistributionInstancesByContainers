using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

public record Category
{
    public CategoryIdentifier Id { get; }

    public string Name { get; }

    public Category(CategoryIdentifier id, string name)
    {
        Id = id;
        Name = name;
    }
}
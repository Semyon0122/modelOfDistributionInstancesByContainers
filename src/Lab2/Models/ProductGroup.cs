using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ProductGroup
{
    public GroupIdentifier Id { get; }

    private readonly IReadOnlyCollection<Category> _categoryTypes;

    public ProductGroup(long id, IReadOnlyCollection<Category> categoryTypes)
    {
        Id = new GroupIdentifier(id);
        _categoryTypes = categoryTypes.Distinct().ToList();
    }

    public bool Contains(Category category)
    {
        return _categoryTypes.Contains(category);
    }
}
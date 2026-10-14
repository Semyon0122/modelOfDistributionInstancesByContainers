using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ProductGroup
{
    public GroupIdentifier Id { get; }

    private readonly IReadOnlyCollection<CategoryType> _categoryTypes;

    public ProductGroup(long id, IReadOnlyCollection<CategoryType> categoryTypes)
    {
        Id = new GroupIdentifier(id);
        _categoryTypes = categoryTypes;
    }

    public static bool Same(ProductGroup? left, ProductGroup? right)
    {
        if ((left is null && right is null) ||
            (left is not null && right is not null && left.Id == right.Id))
        {
            return true;
        }

        return false;
    }

    public bool Contains(CategoryType category)
    {
        return _categoryTypes.Contains(category);
    }
}
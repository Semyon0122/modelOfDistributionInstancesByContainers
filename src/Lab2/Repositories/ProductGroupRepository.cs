using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class ProductGroupRepository : IProductGroupRepository
{
    private readonly Dictionary<GroupIdentifier, ProductGroup> _storage;

    public ProductGroupRepository()
    {
        _storage = new Dictionary<GroupIdentifier, ProductGroup>();
    }

    public ProductGroup? GetById(GroupIdentifier id)
    {
        return _storage.GetValueOrDefault(id);
    }

    public ProductGroup? GetByCategory(CategoryType categoryType)
    {
        foreach (KeyValuePair<GroupIdentifier, ProductGroup> group in _storage)
        {
            if (group.Value.Contains(categoryType))
            {
                return group.Value;
            }
        }

        return null;
    }

    public void Save(ProductGroup group)
    {
        _storage.Add(group.Id, group);
    }
}
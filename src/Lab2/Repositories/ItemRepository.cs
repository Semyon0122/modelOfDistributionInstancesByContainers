using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly Dictionary<ItemIdentifier, Item> _storage;

    public ItemRepository()
    {
        _storage = new Dictionary<ItemIdentifier, Item>();
    }

    public Item? GetById(ItemIdentifier id)
    {
        return _storage.GetValueOrDefault(id);
    }

    public void Save(Item item)
    {
        _storage.Add(item.Id, item);
    }
}
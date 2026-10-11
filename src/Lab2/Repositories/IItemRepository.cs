using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IItemRepository
{
    Item? GetById(ItemIdentifier id);

    void Save(Item item);
}
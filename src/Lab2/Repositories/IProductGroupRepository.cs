using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IProductGroupRepository
{
    ProductGroup? GetById(GroupIdentifier id);

    ProductGroup? GetByCategory(Category categoryType);

    void Save(ProductGroup group);
}
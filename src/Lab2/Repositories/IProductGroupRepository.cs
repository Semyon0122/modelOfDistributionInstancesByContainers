using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IProductGroupRepository
{
    ProductGroup? GetById(GroupIdentifier id);

    ProductGroup? GetByCategory(CategoryType categoryType);

    void Save(ProductGroup group);
}
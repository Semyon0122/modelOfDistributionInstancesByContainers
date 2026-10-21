using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface ICategoryRepository
{
    Category? GetById(CategoryIdentifier id);

    void Save(Category category);
}
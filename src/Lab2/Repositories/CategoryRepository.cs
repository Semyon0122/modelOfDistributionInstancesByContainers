using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly Dictionary<CategoryIdentifier, Category> _storage;

    public CategoryRepository()
    {
        _storage = new Dictionary<CategoryIdentifier, Category>();
    }

    public Category? GetById(CategoryIdentifier id)
    {
        return _storage.GetValueOrDefault(id);
    }

    public void Save(Category category)
    {
        _storage.Add(category.Id, category);
    }
}
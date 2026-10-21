namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Categories
{
    private readonly List<Categories> _categories;

    public IReadOnlyCollection<Categories> CategoriesOut => _categories.AsReadOnly();

    public Categories(IReadOnlyCollection<Categories> categories)
    {
        _categories = categories.ToList();
    }
}
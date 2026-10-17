using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class TestConstants
{
    static TestConstants()
    {
        GroupRepository.Save(ProductGroup1);
        GroupRepository.Save(ProductGroup2);
        GroupRepository.Save(ProductGroup3);
        GroupRepository.Save(ProductGroup4);
        GroupRepository.Save(ProductGroup5);
        GroupRepository.Save(ProductGroup6);
        GroupRepository.Save(ProductGroup7);
    }

    // CategoryTypes
    public const CategoryType ElectronicsCategory = CategoryType.Electronics;
    public const CategoryType NoneCategory = CategoryType.None;
    public const CategoryType JeweleryCategory = CategoryType.Jewelry;
    public const CategoryType CosmeticsCategory = CategoryType.Cosmetics;
    public const CategoryType ClothesCategory = CategoryType.Clothes;
    public const CategoryType FurnitureCategory = CategoryType.Furniture;
    public const CategoryType FruitsAndVegetablesCategory = CategoryType.FruitsAndVegetables;
    public const CategoryType BakeryCategory = CategoryType.Bakery;
    public const CategoryType PaperCategory = CategoryType.Paper;
    public const CategoryType ScissorsCategory = CategoryType.Scissors;
    public const CategoryType StoneCategory = CategoryType.Stone;

    // ProductGroups
    public static readonly ProductGroup ProductGroup1 =
        new ProductGroup(1, new List<CategoryType>() { PaperCategory });

    public static readonly ProductGroup ProductGroup2 =
        new ProductGroup(2, new List<CategoryType>() { ScissorsCategory });

    public static readonly ProductGroup ProductGroup3 =
        new ProductGroup(3, new List<CategoryType>() { StoneCategory });

    public static readonly ProductGroup ProductGroup4 =
        new ProductGroup(4, new List<CategoryType>()
        {
            ElectronicsCategory, JeweleryCategory, ClothesCategory, FurnitureCategory,
        });

    public static readonly ProductGroup ProductGroup5 =
        new ProductGroup(5, new List<CategoryType>() { CosmeticsCategory });

    public static readonly ProductGroup ProductGroup6 =
        new ProductGroup(6, new List<CategoryType>() { BakeryCategory, FruitsAndVegetablesCategory });

    public static readonly ProductGroup ProductGroup7 =
        new ProductGroup(7, new List<CategoryType>() { FurnitureCategory });

    // Group Repository
    public static readonly IProductGroupRepository GroupRepository = new ProductGroupRepository();

    // ExpirationDates
    public static readonly ExpirationDate ExpirationDate1 =
        new ExpirationDate(new DateTimeOffset(2027, 10, 14, 0, 0, 0, TimeSpan.FromDays(0)));

    public static readonly ExpirationDate ExpirationDate2 =
        new ExpirationDate(new DateTimeOffset(2025, 10, 14, 0, 0, 0, TimeSpan.FromDays(0)));
}
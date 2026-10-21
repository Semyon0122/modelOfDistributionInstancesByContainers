using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
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
    public static readonly Category ElectronicsCategory = new(new CategoryIdentifier(1), "Electronics");
    public static readonly Category NoneCategory = new(new CategoryIdentifier(2), "None");
    public static readonly Category JeweleryCategory = new(new CategoryIdentifier(3), "Jewelery");
    public static readonly Category CosmeticsCategory = new(new CategoryIdentifier(4), "Cosmetics");
    public static readonly Category ClothesCategory = new(new CategoryIdentifier(5), "Clothes");
    public static readonly Category FurnitureCategory = new(new CategoryIdentifier(6), "Furniture");
    public static readonly Category FruitsAndVegetablesCategory = new(new CategoryIdentifier(7), "FruitsAndVegetables");
    public static readonly Category BakeryCategory = new(new CategoryIdentifier(8), "Bakery");
    public static readonly Category PaperCategory = new(new CategoryIdentifier(9), "Paper");
    public static readonly Category ScissorsCategory = new(new CategoryIdentifier(10), "Scissors");
    public static readonly Category StoneCategory = new(new CategoryIdentifier(11), "Stone");

    // ProductGroups
    public static readonly ProductGroup ProductGroup1 =
        new ProductGroup(1, new List<Category>() { PaperCategory });

    public static readonly ProductGroup ProductGroup2 =
        new ProductGroup(2, new List<Category>() { ScissorsCategory });

    public static readonly ProductGroup ProductGroup3 =
        new ProductGroup(3, new List<Category>() { StoneCategory });

    public static readonly ProductGroup ProductGroup4 =
        new ProductGroup(4, new List<Category>()
        {
            ElectronicsCategory, JeweleryCategory, ClothesCategory, FurnitureCategory,
        });

    public static readonly ProductGroup ProductGroup5 =
        new ProductGroup(5, new List<Category>() { CosmeticsCategory });

    public static readonly ProductGroup ProductGroup6 =
        new ProductGroup(6, new List<Category>() { BakeryCategory, FruitsAndVegetablesCategory });

    public static readonly ProductGroup ProductGroup7 =
        new ProductGroup(7, new List<Category>() { FurnitureCategory });

    // Group Repository
    public static readonly IProductGroupRepository GroupRepository = new ProductGroupRepository();

    // ExpirationDates
    public static readonly ExpirationDate ExpirationDate1 =
        new ExpirationDate(new DateTimeOffset(2027, 10, 14, 0, 0, 0, TimeSpan.FromDays(0)));

    public static readonly ExpirationDate ExpirationDate2 =
        new ExpirationDate(new DateTimeOffset(2025, 10, 14, 0, 0, 0, TimeSpan.FromDays(0)));
}
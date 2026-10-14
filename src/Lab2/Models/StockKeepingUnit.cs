using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class StockKeepingUnit
{
    public StockKeepingUnitIdentifier Id { get; }

    public CategoryType CategoryType { get; }

    public VolumetricWeightCharacteristics Characteristics { get; private set; }

    public ProductGroup? Group { get; }

    public StockKeepingUnit(
        CategoryType categoryType,
        VolumetricWeightCharacteristics characteristics)
    {
        Id = new();
        CategoryType = categoryType;
        Characteristics = characteristics;
    }

    public StockKeepingUnit(
        CategoryType categoryType,
        VolumetricWeightCharacteristics characteristics,
        ProductGroup group)
    {
        Id = new();
        CategoryType = categoryType;
        Characteristics = characteristics;
        Group = group;
    }

    public void AddCharacteristics(VolumetricWeightCharacteristics characteristics)
    {
        Characteristics += characteristics;
    }
}
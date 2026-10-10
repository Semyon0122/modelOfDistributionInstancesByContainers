using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class StockKeepingUnit
{
    public StockKeepingUnitIdentifier Id { get; } = new();

    public CategoryType CategoryType { get; }

    public VolumetricWeightCharacteristics Characteristics { get; }

    public StockKeepingUnit(CategoryType categoryType, VolumetricWeightCharacteristics characteristics)
    {
        CategoryType = categoryType;
        Characteristics = characteristics;
    }
}
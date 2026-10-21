using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class StockKeepingUnit
{
    public StockKeepingUnitIdentifier Id { get; }

    public Category CategoryType { get; }

    public VolumetricWeightCharacteristics Characteristics { get; private set; }

    public StockKeepingUnit(
        Category categoryType,
        VolumetricWeightCharacteristics characteristics)
    {
        Id = new();
        CategoryType = categoryType;
        Characteristics = characteristics;
    }
}
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Tare
{
    public TareIdentifier Id { get; }

    public Dictionary<ItemIdentifier, Item> Items { get; }

    public VolumetricWeightCharacteristics MaxCapacity { get; }

    public VolumetricWeightCharacteristics Capacity { get; private set; }

    public ProductGroup? Group { get; private set; }

    public Tare(VolumetricWeightCharacteristics maxCapacity)
    {
        Id = new TareIdentifier();
        Items = new Dictionary<ItemIdentifier, Item>();
        Capacity = VolumetricWeightCharacteristics.EmptyCapacity();
        MaxCapacity = maxCapacity;
    }

    public void SetProductGroup(ProductGroup group)
    {
        Group = group;
    }

    public void AddCapacity(VolumetricWeightCharacteristics capacity)
    {
        Capacity += capacity;
    }
}
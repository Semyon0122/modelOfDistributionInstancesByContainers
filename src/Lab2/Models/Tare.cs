using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Tare
{
    public TareIdentifier Id { get; }

    public LinkedList<Item> Items { get; }

    public VolumetricWeightCharacteristics MaxCapacity { get; }

    public VolumetricWeightCharacteristics Capacity { get; private set; }

    public Tare(VolumetricWeightCharacteristics maxCapacity)
    {
        Id = new TareIdentifier();
        Items = new LinkedList<Item>();
        Capacity = VolumetricWeightCharacteristics.EmptyCapacity();
        MaxCapacity = maxCapacity;
    }

    public void AddCapacity(VolumetricWeightCharacteristics capacity)
    {
        Capacity += capacity;
    }
}
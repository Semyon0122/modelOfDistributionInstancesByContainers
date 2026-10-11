using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Pallet
{
    public PalletIdentifier Id { get; }

    public Dictionary<TareIdentifier, Tare> Tares { get; }

    public VolumetricWeightCharacteristics Capacity { get; }

    public VolumetricWeightCharacteristics MaxCapacity { get; }

    public Pallet(VolumetricWeightCharacteristics maxCapacity)
    {
        Id = new PalletIdentifier();
        Tares = new Dictionary<TareIdentifier, Tare>();
        Capacity = VolumetricWeightCharacteristics.EmptyCapacity();
        MaxCapacity = maxCapacity;
    }
}
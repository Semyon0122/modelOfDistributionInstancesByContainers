namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

public record VolumetricWeightCharacteristics
{
    private readonly Volume _volume;
    private readonly Weight _weight;

    public VolumetricWeightCharacteristics(Volume volume, Weight weight)
    {
        _volume = volume;
        _weight = weight;
    }

    public static VolumetricWeightCharacteristics EmptyCapacity() => new(Volume.EmptyVolume(), Weight.EmptyWeight());

    public static VolumetricWeightCharacteristics operator +(
        VolumetricWeightCharacteristics left,
        VolumetricWeightCharacteristics right)
    {
        return new VolumetricWeightCharacteristics(
            left._volume + right._volume,
            left._weight + right._weight);
    }

    public static VolumetricWeightCharacteristics operator -(
        VolumetricWeightCharacteristics left,
        VolumetricWeightCharacteristics right)
    {
        return new VolumetricWeightCharacteristics(
            left._volume - right._volume,
            left._weight - right._weight);
    }

    public static bool operator >(
        VolumetricWeightCharacteristics left,
        VolumetricWeightCharacteristics right)
        => left._volume > right._volume &&
           left._weight > right._weight;

    public static bool operator <(
        VolumetricWeightCharacteristics left,
        VolumetricWeightCharacteristics right)
        => left._volume < right._volume &&
           left._weight < right._weight;

    public static bool operator >=(
        VolumetricWeightCharacteristics left,
        VolumetricWeightCharacteristics right)
        => left._volume >= right._volume &&
           left._weight >= right._weight;

    public static bool operator <=(
        VolumetricWeightCharacteristics left,
        VolumetricWeightCharacteristics right)
        => left._volume <= right._volume &&
           left._weight <= right._weight;
}
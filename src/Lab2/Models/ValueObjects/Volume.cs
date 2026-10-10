namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

public record Volume
{
    public double Value { get; }

    public Volume(double value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value, "Volume must be positive!");

        Value = value;
    }

    public static Volume EmptyVolume() => new(0);

    public static Volume operator +(Volume left, Volume right) => new(left.Value + right.Value);

    public static Volume operator -(Volume left, Volume right) => new(left.Value - right.Value);

    public static bool operator >(Volume left, Volume right) => left.Value > right.Value;

    public static bool operator <(Volume left, Volume right) => left.Value < right.Value;

    public static bool operator >=(Volume left, Volume right) => left.Value >= right.Value;

    public static bool operator <=(Volume left, Volume right) => left.Value <= right.Value;
}
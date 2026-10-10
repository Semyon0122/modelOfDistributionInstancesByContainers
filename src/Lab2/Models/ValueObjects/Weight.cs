namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

public record Weight
{
    public double Value { get; }

    public Weight(double value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value, "Weight must be positive!");

        Value = value;
    }

    public static Weight EmptyWeight() => new(0);

    public static Weight operator +(Weight left, Weight right) => new(left.Value + right.Value);

    public static Weight operator -(Weight left, Weight right) => new(left.Value - right.Value);

    public static bool operator >(Weight left, Weight right) => left.Value > right.Value;

    public static bool operator <(Weight left, Weight right) => left.Value < right.Value;

    public static bool operator >=(Weight left, Weight right) => left.Value >= right.Value;

    public static bool operator <=(Weight left, Weight right) => left.Value <= right.Value;
}
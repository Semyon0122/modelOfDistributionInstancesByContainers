namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

public record ExpirationDate
{
    public DateTimeOffset Value { get; }

    public ExpirationDate(DateTimeOffset value)
    {
        Value = value;
    }

    public bool IsItemExpired()
    {
        return Value > DateTimeOffset.UtcNow;
    }

    public static bool operator >(ExpirationDate left, DateTimeOffset right) => left.Value > right;

    public static bool operator <(ExpirationDate left, DateTimeOffset right) => left.Value < right;

    public static bool operator >=(ExpirationDate left, DateTimeOffset right) => left.Value >= right;

    public static bool operator <=(ExpirationDate left, DateTimeOffset right) => left.Value <= right;
}
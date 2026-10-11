namespace Itmo.ObjectOrientedProgramming.Lab2.Results.TareResults;

public abstract record ResultTareAddItem
{
    public sealed record Success() : ResultTareAddItem;

    public sealed record Failure(string Message) : ResultTareAddItem;
}
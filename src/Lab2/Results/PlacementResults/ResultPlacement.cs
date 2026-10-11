namespace Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

public abstract record ResultPlacement
{
    public sealed record Success() : ResultPlacement;

    public sealed record Failure(string Message) : ResultPlacement;
}
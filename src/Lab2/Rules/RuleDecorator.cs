using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public abstract class RuleDecorator : IPlacementRule
{
    protected IPlacementRule Inner { get; }

    protected RuleDecorator(IPlacementRule inner)
    {
        Inner = inner;
    }

    public abstract ResultPlacement TryAdd(Item item);
}
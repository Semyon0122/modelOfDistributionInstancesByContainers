using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class ExpirationRuleExpired : RuleDecorator
{
    public ExpirationRuleExpired(IPlacementRule rule) : base(rule) { }

    public override ResultPlacement TryAdd(Item item)
    {
        if (item.Date is null || item.Date > DateTimeOffset.UtcNow)
        {
            return new ResultPlacement.Failure("Mode is not suitable for rule!");
        }

        return Inner.TryAdd(item);
    }
}
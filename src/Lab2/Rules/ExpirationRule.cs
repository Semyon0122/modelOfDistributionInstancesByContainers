using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class ExpirationRule : RuleDecorator
{
    private readonly ExpirationMode _mode;

    public ExpirationRule(ExpirationMode mode, IPlacementRule rule) : base(rule)
    {
        _mode = mode;
    }

    public override ResultPlacement TryAdd(Item item)
    {
        if ((_mode == ExpirationMode.Expired && item.Date > DateTimeOffset.UtcNow) ||
            (_mode == ExpirationMode.NotExpired && item.Date <= DateTimeOffset.UtcNow))
        {
            return new ResultPlacement.Failure("Mode is not suitable for rule!");
        }

        return Inner.TryAdd(item);
    }
}
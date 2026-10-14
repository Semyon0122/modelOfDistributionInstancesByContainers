using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class LoggingRule : RuleDecorator
{
    private readonly ILogger _logger;

    public LoggingRule(ILogger logger, IPlacementRule rule) : base(rule)
    {
        _logger = logger;
    }

    public override ResultPlacement TryAdd(Item item)
    {
        ResultPlacement result = Inner.TryAdd(item);

        _logger.Log(result is ResultPlacement.Failure failure ?
            $"Item {item.Id} not placed: {failure.Message}" :
            $"Item {item.Id} successfully placed");

        return result;
    }
}
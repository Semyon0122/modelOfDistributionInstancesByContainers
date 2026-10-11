using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class PalletRule : IPlacementRule
{
    private readonly IReadOnlyCollection<IPlacementRule> _itemsOn;

    public PalletRule(IReadOnlyCollection<IPlacementRule> itemsOn)
    {
        _itemsOn = itemsOn;
    }

    public ResultPlacement TryAdd(Item item)
    {
        foreach (IPlacementRule itemOn in _itemsOn)
        {
            ResultPlacement result = itemOn.TryAdd(item);

            if (result is ResultPlacement.Success)
            {
                return new ResultPlacement.Success();
            }
        }

        return new ResultPlacement.Failure("No tare on pallet accepted item!");
    }
}
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;
using Itmo.ObjectOrientedProgramming.Lab2.Results.TareResults;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class TareRule : IPlacementRule
{
    private readonly TareIdentifier _id;

    private readonly ITareService _service;

    public TareRule(TareIdentifier id, ITareService service)
    {
        _id = id;
        _service = service;
    }

    public ResultPlacement TryAdd(Item item)
    {
        ResultTareAddItem result = _service.AddItemInTare(_id, item);

        if (result is ResultTareAddItem.Success)
        {
            return new ResultPlacement.Success();
        }

        if (result is ResultTareAddItem.Failure failure)
        {
            return new ResultPlacement.Failure(failure.Message);
        }

        return new ResultPlacement.Failure("Could not add item!");
    }
}
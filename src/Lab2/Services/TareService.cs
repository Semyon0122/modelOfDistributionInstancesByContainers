using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results.TareResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class TareService : ITareService
{
    private readonly ITareRepository _tareRepository;

    public TareService(ITareRepository tareRepository)
    {
        _tareRepository = tareRepository;
    }

    public ResultTareAddItem AddItemInTare(TareIdentifier tareId, Item item)
    {
        Tare? tare = _tareRepository.GetById(tareId);

        if (tare is not null)
        {
            if (tare.Capacity + item.Unit.Characteristics > tare.MaxCapacity)
            {
                return new ResultTareAddItem.Failure($"No more capacity in tare {tareId} to add item {item.Id}!");
            }

            if (tare.Items.TryGetValue(item.Id, out Item? tareItem))
            {
                tareItem.Unit.AddCharacteristics(item.Unit.Characteristics);
            }
            else
            {
                tare.Items.Add(item.Id, item);
            }

            tare.AddCapacity(item.Unit.Characteristics);

            return new ResultTareAddItem.Success();
        }

        return new ResultTareAddItem.Failure("Id is not exist!");
    }
}
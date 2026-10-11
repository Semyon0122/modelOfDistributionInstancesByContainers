using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results.TareResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class TareService : ITareService
{
    private readonly ITareRepository _tareRepository;
    private readonly IItemRepository _itemRepository;

    public TareService(ITareRepository tareRepository, IItemRepository itemRepository)
    {
        _tareRepository = tareRepository;
        _itemRepository = itemRepository;
    }

    public ResultTareAddItem AddItemInTare(TareIdentifier tareId, ItemIdentifier itemId)
    {
        Tare? tare = _tareRepository.GetById(tareId);
        Item? item = _itemRepository.GetById(itemId);

        if (tare is not null && item is not null)
        {
            if (tare.Capacity + item.Unit.Characteristics > tare.MaxCapacity)
            {
                return new ResultTareAddItem.Failure($"No more capacity in tare {tareId} to add item {itemId}!");
            }

            if (tare.Items.TryGetValue(item.Id, out Item? tareItem))
            {
                tareItem.Unit.AddCharacteristics(item.Unit.Characteristics);
            }
            else
            {
                tare.Items.Add(itemId, item);
            }

            tare.AddCapacity(item.Unit.Characteristics);

            return new ResultTareAddItem.Success();
        }

        return new ResultTareAddItem.Failure("Id is not exist!");
    }
}
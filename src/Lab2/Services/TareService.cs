using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results.TareResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class TareService : ITareService
{
    private readonly ITareRepository _tareRepository;
    private readonly IProductGroupRepository _groupRepository;

    public TareService(ITareRepository tareRepository, IProductGroupRepository groupRepository)
    {
        _tareRepository = tareRepository;
        _groupRepository = groupRepository;
    }

    public ResultTareAddItem AddItemInTare(TareIdentifier tareId, Item item)
    {
        Tare? tare = _tareRepository.GetById(tareId);

        if (tare is null)
        {
            return new ResultTareAddItem.Failure("Tare is not exist!");
        }

        if (tare.Capacity + item.Unit.Characteristics > tare.MaxCapacity)
        {
            return new ResultTareAddItem.Failure($"No more capacity in tare {tareId} to add item {item.Id}!");
        }

        if (tare.Group is null)
        {
            ProductGroup? itemGroup = _groupRepository.GetByCategory(item.Unit.CategoryType);

            if (itemGroup is not null && tare.Items.Count == 0)
            {
                tare.SetProductGroup(itemGroup);
            }

            if (itemGroup is not null && tare.Items.Count != 0)
            {
                return new ResultTareAddItem.Failure("These products belong to different product groups!");
            }
        }
        else
        {
            if (!tare.Group.Contains(item.Unit.CategoryType))
            {
                return new ResultTareAddItem.Failure("These products belong to different product groups!");
            }
        }

        tare.Items.Add(item.Id, item);
        tare.AddCapacity(item.Unit.Characteristics);

        return new ResultTareAddItem.Success();
    }
}
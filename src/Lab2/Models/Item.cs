using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Item
{
    public ItemIdentifier Id { get; } = new();

    public StockKeepingUnit Unit { get; }

    public ExpirationDate Date { get; }

    public Item(StockKeepingUnit unit, ExpirationDate date)
    {
        Unit = unit;
        Date = date;
    }

    public bool IsItemExpired()
    {
        return Date.IsItemExpired();
    }
}
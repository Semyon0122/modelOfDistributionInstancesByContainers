using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Item
{
    public ItemIdentifier Id { get; }

    public StockKeepingUnit Unit { get; }

    public ExpirationDate Date { get; }

    public Item(StockKeepingUnit unit, ExpirationDate date)
    {
        Id = new();
        Unit = unit;
        Date = date;
    }

    public bool IsItemExpired()
    {
        return Date.IsItemExpired();
    }
}
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Results.TareResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface ITareService
{
    ResultTareAddItem AddItemInTare(TareIdentifier tareId, ItemIdentifier itemId);
}
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public interface IPlacementRule
{
    ResultPlacement TryAdd(Item item);
}
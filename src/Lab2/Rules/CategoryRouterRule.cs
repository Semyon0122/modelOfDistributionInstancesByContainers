using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Rules;

public class CategoryRouterRule : IPlacementRule
{
    private readonly Dictionary<CategoryType, IPlacementRule> _routes;

    private readonly IPlacementRule _default;

    public CategoryRouterRule(
        Dictionary<CategoryType, IPlacementRule> routes,
        IPlacementRule defaultRoute)
    {
        _routes = routes;
        _default = defaultRoute;
    }

    public ResultPlacement TryAdd(Item item)
    {
        if (_routes.TryGetValue(item.Unit.CategoryType, out IPlacementRule? route))
        {
            return route.TryAdd(item);
        }

        return _default.TryAdd(item);
    }
}
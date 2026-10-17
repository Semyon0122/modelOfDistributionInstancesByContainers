using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;
using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class RouterTests
{
    [Fact]
    public void AddInTare_ShouldSuccessful_WhenRouterDefault()
    {
        // arrange
        var bakeryItem = new Item(
            new StockKeepingUnit(
                TestConstants.ElectronicsCategory,
                new VolumetricWeightCharacteristics(new Volume(10), new Weight(10))),
            TestConstants.ExpirationDate1);

        var tare = new Tare(new VolumetricWeightCharacteristics(new Volume(20), new Weight(20)));

        var tareRepository = new TareRepository();
        tareRepository.Save(tare);

        var tareService = new TareService(tareRepository, TestConstants.GroupRepository);

        var tareRule = new TareRule(tare.Id, tareService);
        var router = new CategoryRouterRule(new Dictionary<CategoryType, IPlacementRule>(), tareRule);

        // act
        ResultPlacement result = router.TryAdd(bakeryItem);

        // assert
        Assert.IsType<ResultPlacement.Success>(result);
        Assert.Single(tare.Items);
    }

    [Fact]
    public void AddInTare_ShouldSuccessful_WhenRouterWithMapping()
    {
        // arrange
        var electronicItem = new Item(
            new StockKeepingUnit(
                TestConstants.ElectronicsCategory,
                new VolumetricWeightCharacteristics(new Volume(10), new Weight(10))),
            TestConstants.ExpirationDate1);

        var fruitsAndVegetablesItem = new Item(
            new StockKeepingUnit(
                TestConstants.FruitsAndVegetablesCategory,
                new VolumetricWeightCharacteristics(new Volume(10), new Weight(10))),
            TestConstants.ExpirationDate1);

        var tare1 = new Tare(new VolumetricWeightCharacteristics(new Volume(200), new Weight(200)));
        var tare2 = new Tare(new VolumetricWeightCharacteristics(new Volume(200), new Weight(200)));

        var tareRepository = new TareRepository();
        tareRepository.Save(tare1);
        tareRepository.Save(tare2);

        var tareService = new TareService(tareRepository, TestConstants.GroupRepository);

        var tareRule1 = new TareRule(tare1.Id, tareService);
        var tareRule2 = new TareRule(tare2.Id, tareService);
        var emptyTareRule = new TareRule(new TareIdentifier(), tareService);

        var mapping = new Dictionary<CategoryType, IPlacementRule>();
        mapping.Add(TestConstants.ElectronicsCategory, tareRule1);
        mapping.Add(TestConstants.FruitsAndVegetablesCategory, tareRule2);

        var router = new CategoryRouterRule(mapping, emptyTareRule);

        // act
        ResultPlacement result1 = router.TryAdd(electronicItem);
        ResultPlacement result2 = router.TryAdd(fruitsAndVegetablesItem);

        // assert
        Assert.IsType<ResultPlacement.Success>(result1);
        Assert.IsType<ResultPlacement.Success>(result2);

        Assert.Single(tare1.Items);
        Assert.Equal(tare1.Items[electronicItem.Id], electronicItem);

        Assert.Single(tare2.Items);
        Assert.Equal(tare2.Items[fruitsAndVegetablesItem.Id], fruitsAndVegetablesItem);
    }
}
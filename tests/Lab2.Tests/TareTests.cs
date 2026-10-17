using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;
using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TareTests
{
    [Fact]
    public void AddInTare_ShouldFailed_WhenDifferentProductGroups()
    {
        // arrange
        var paperItem = new Item(
            new StockKeepingUnit(
                TestConstants.PaperCategory,
                new VolumetricWeightCharacteristics(new Volume(1), new Weight(1))),
            TestConstants.ExpirationDate1);

        var scissorsItem = new Item(
            new StockKeepingUnit(
                TestConstants.ScissorsCategory,
                new VolumetricWeightCharacteristics(new Volume(1), new Weight(1))),
            TestConstants.ExpirationDate1);

        var stoneItem = new Item(
            new StockKeepingUnit(
                TestConstants.StoneCategory,
                new VolumetricWeightCharacteristics(new Volume(1), new Weight(1))),
            TestConstants.ExpirationDate1);

        var tare = new Tare(new VolumetricWeightCharacteristics(new Volume(200), new Weight(200)));

        var tareRepository = new TareRepository();
        tareRepository.Save(tare);

        var tareService = new TareService(tareRepository, TestConstants.GroupRepository);

        tareService.AddItemInTare(tare.Id, paperItem);

        var tareRule = new TareRule(tare.Id, tareService);

        // act
        ResultPlacement result1 = tareRule.TryAdd(scissorsItem);
        ResultPlacement result2 = tareRule.TryAdd(stoneItem);

        // assert
        Assert.IsType<ResultPlacement.Failure>(result1);
        Assert.IsType<ResultPlacement.Failure>(result2);
        Assert.Single(tare.Items);

        if (result1 is ResultPlacement.Failure failure)
        {
            Assert.Equal("These products belong to different product groups!", failure.Message);
        }
    }

    [Fact]
    public void AddInTare_ShouldFailed_WhenCapacityOverfilled()
    {
        // arrange
        var electronicItem1 = new Item(
            new StockKeepingUnit(
                TestConstants.ElectronicsCategory,
                new VolumetricWeightCharacteristics(new Volume(20), new Weight(20))),
            TestConstants.ExpirationDate1);

        var electronicItem2 = new Item(
            new StockKeepingUnit(
                TestConstants.ElectronicsCategory,
                new VolumetricWeightCharacteristics(new Volume(20), new Weight(20))),
            TestConstants.ExpirationDate1);

        var tare = new Tare(new VolumetricWeightCharacteristics(new Volume(20), new Weight(20)));

        var tareRepository = new TareRepository();
        tareRepository.Save(tare);

        var tareService = new TareService(tareRepository, TestConstants.GroupRepository);

        tareService.AddItemInTare(tare.Id, electronicItem1);

        var tareRule = new TareRule(tare.Id, tareService);

        // act
        ResultPlacement result = tareRule.TryAdd(electronicItem2);

        // assert
        Assert.IsType<ResultPlacement.Failure>(result);
        Assert.Single(tare.Items);

        if (result is ResultPlacement.Failure failure)
        {
            Assert.Equal(
                $"No more capacity in tare {tare.Id} to add item {electronicItem2.Id}!", failure.Message);
        }
    }

    [Fact]
    public void AddInTare_ShouldFailed_WhenItemWithoutProductCategory()
    {
        // arrange
        var electronicItem1 = new Item(
            new StockKeepingUnit(
                TestConstants.ElectronicsCategory,
                new VolumetricWeightCharacteristics(new Volume(20), new Weight(20))),
            TestConstants.ExpirationDate1);

        var electronicItem2 = new Item(
            new StockKeepingUnit(
                TestConstants.NoneCategory,
                new VolumetricWeightCharacteristics(new Volume(20), new Weight(20))),
            TestConstants.ExpirationDate1);

        var tare = new Tare(new VolumetricWeightCharacteristics(new Volume(200), new Weight(200)));

        var tareRepository = new TareRepository();
        tareRepository.Save(tare);

        var tareService = new TareService(tareRepository, TestConstants.GroupRepository);

        tareService.AddItemInTare(tare.Id, electronicItem1);

        var tareRule = new TareRule(tare.Id, tareService);

        var logger = new CountingLogger();
        var loggingRule = new LoggingRule(logger, tareRule);

        // act
        ResultPlacement result = loggingRule.TryAdd(electronicItem2);

        // assert
        Assert.IsType<ResultPlacement.Failure>(result);
        Assert.Single(tare.Items);

        if (result is ResultPlacement.Failure failure)
        {
            Assert.Equal(
                $"Item {electronicItem2.Id} not placed: {failure.Message}", logger.Messages.ElementAt(0));
        }
    }
}
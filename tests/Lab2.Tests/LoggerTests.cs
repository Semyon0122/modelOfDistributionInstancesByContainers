using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;
using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class LoggerTests
{
    [Fact]
    public void LoggingAddInTare_ShouldSuccessful_WhenSuccessfulAndUnsuccessfulAdd()
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

        var tareRule = new TareRule(tare.Id, tareService);

        var logger = new CountingLogger();
        var loggingRule = new LoggingRule(logger, tareRule);

        // act
        ResultPlacement result1 = loggingRule.TryAdd(electronicItem1);
        ResultPlacement result2 = loggingRule.TryAdd(electronicItem2);

        // assert
        Assert.IsType<ResultPlacement.Success>(result1);
        Assert.IsType<ResultPlacement.Failure>(result2);

        if (result1 is ResultPlacement.Success)
        {
            Assert.Equal(
                $"Item {electronicItem1.Id} successfully placed", logger.Messages.ElementAt(0));
        }

        if (result2 is ResultPlacement.Failure failure)
        {
            Assert.Equal(
                $"Item {electronicItem2.Id} not placed: {failure.Message}", logger.Messages.ElementAt(1));
        }
    }
}
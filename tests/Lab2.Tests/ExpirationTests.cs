using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results.PlacementResults;
using Itmo.ObjectOrientedProgramming.Lab2.Rules;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ExpirationTests
{
    [Fact]
    public void AddInTare_ShouldSuccessful_WhenExpiredAndNonExpiredTares()
    {
        // arrange
        var nonExpiredItem = new Item(
            new StockKeepingUnit(
                TestConstants.ElectronicsCategory,
                new VolumetricWeightCharacteristics(new Volume(10), new Weight(10))),
            TestConstants.ExpirationDate1);

        var expiredItem = new Item(
            new StockKeepingUnit(
                TestConstants.ElectronicsCategory,
                new VolumetricWeightCharacteristics(new Volume(10), new Weight(10))),
            TestConstants.ExpirationDate2);

        var tareWithNonExpired = new Tare(new VolumetricWeightCharacteristics(new Volume(200), new Weight(200)));
        var tareWithExpired = new Tare(new VolumetricWeightCharacteristics(new Volume(200), new Weight(200)));

        var tareRepository = new TareRepository();
        tareRepository.Save(tareWithNonExpired);
        tareRepository.Save(tareWithExpired);

        var tareService = new TareService(tareRepository, TestConstants.GroupRepository);

        var tareRule1 = new TareRule(tareWithNonExpired.Id, tareService);
        var tareRule2 = new TareRule(tareWithExpired.Id, tareService);

        var nonExpiredRule = new ExpirationRuleNotExpiredOrNull(tareRule1);
        var expiredRule = new ExpirationRuleExpired(tareRule2);

        var palletRule = new PalletRule(new List<IPlacementRule>() { nonExpiredRule, expiredRule });

        var logger = new CountingLogger();
        var loggingRule = new LoggingRule(logger, palletRule);

        // act
        ResultPlacement result1 = loggingRule.TryAdd(nonExpiredItem);
        ResultPlacement result2 = loggingRule.TryAdd(expiredItem);

        // assert
        Assert.IsType<ResultPlacement.Success>(result1);
        Assert.IsType<ResultPlacement.Success>(result2);

        Assert.Equal(nonExpiredItem, tareWithNonExpired.Items.Last());
        Assert.Equal(expiredItem, tareWithExpired.Items.Last());

        if (result1 is ResultPlacement.Success && result2 is ResultPlacement.Success)
        {
            Assert.Equal($"Item {nonExpiredItem.Id} successfully placed", logger.Messages.ElementAt(0));
            Assert.Equal($"Item {expiredItem.Id} successfully placed", logger.Messages.ElementAt(1));
        }
    }
}
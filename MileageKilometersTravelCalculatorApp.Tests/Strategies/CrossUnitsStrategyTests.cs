using Xunit;
using MileageKilometersTravelCalculatorApp.Service.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using FluentAssertions;

namespace MileageKilometersTravelCalculatorApp.Service.Strategy.Tests
{
    public class CrossUnitsStrategyTests
    {

        [Theory()]
        [InlineData(DistanceUnits.Kilometers, 100, 1000, 6, 12)]
        [InlineData(DistanceUnits.Miles, 100, 1000, 16, 5)]
        public void GetTimeTest_WhenGivenDistanceUnitsSpeedAndDistanceReturnsGivenTime(DistanceUnits distanceUnits, double speed, double distance, int hours, int minutes)
        {
            //arrange 

            CrossUnitsStrategy strategy = new CrossUnitsStrategy(distanceUnits);

            //act

            Time timeResoult = strategy.GetTime(speed, distance);

            //assert

            timeResoult.Hours.Should().Be(hours);
            timeResoult.Minutes.Should().Be(minutes);
        }
    }
}
using Xunit;
using MileageKilometersTravelCalculatorApp.Service.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using FluentAssertions;

namespace MileageKilometersTravelCalculatorApp.Service.Strategies.Tests
{
    public class UnifiedUnitsStrategyTests
    {
        [Theory()]
        [InlineData(100, 1000, 10, 0)]
        [InlineData(1000, 1100, 1, 6)]
        public void GetTimeTest_WhenGivenSpeedAndDistanceReturnsGivenTime(double speed, double distance, int hours, int minutes)
        {
            //arrange 

            UnifiedUnitsStrategy strategy = new UnifiedUnitsStrategy();

            //act

            Time timeResoult = strategy.GetTime(speed, distance);

            //assert

            timeResoult.Hours.Should().Be(hours);
            timeResoult.Minutes.Should().Be(minutes);
        }
    }
}
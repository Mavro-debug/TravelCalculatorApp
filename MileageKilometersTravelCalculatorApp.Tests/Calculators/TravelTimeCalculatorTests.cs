using Xunit;
using MileageKilometersTravelCalculatorApp.Service.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Strategies;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using FluentAssertions;

namespace MileageKilometersTravelCalculatorApp.Service.Calculators.Tests
{
    public class TravelTimeCalculatorTests
    {
        [Fact()]
        public void CalculateTravelTime_WhenGivenITravelTimeCalculatorStrategy_ReturnsGetTimeResoult()
        {
            //arrange
            var travelCalculatorStrategy = new Mock<ITravelTimeCalculatorStrategy>();

            travelCalculatorStrategy.Setup(x => x.GetTime(It.IsAny<double>(), It.IsAny<double>()))
                .Returns(new Time() { Hours = 5, Minutes = 5 });


            TravelTimeCalculator travelTimeCalculator = new TravelTimeCalculator(travelCalculatorStrategy.Object);


            //act

            Time timeResoult = travelTimeCalculator.CalculateTravelTime(5, 5);



            //assert

            timeResoult.Hours.Should().Be(5);
            timeResoult.Minutes.Should().Be(5);

        }
    }
}
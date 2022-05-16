using FluentAssertions;
using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using MileageKilometersTravelCalculatorApp.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MileageKilometersTravelCalculatorApp.Tests
{

    public class TravelCalculatorFacadeTests
    {
        private const string Comment1 = "You will reach your destination in literally no time";
        private const string Comment2 = "No need to prepare, you will be on the site in on time";
        private const string Comment3 = "This is not a long ride but it is always good to have a nice mixtape with you";
        private const string Comment4 = "This is some ride. It is always a good idea to prepare a solid mixtape with you";
        private const string Comment5 = "This is a long ride! There are some great podcasts to be found on the Internet";
        private const string Comment6 = "This is a long ride!!! Podcasts, mixtapes and coffee, that is the way to go";
        private const string Comment7 = "This is a long ride!!! I think you should buy an ebook for the occasion";

        [Theory]
        [InlineData(72, 544, DistanceUnits.Kilometers, 8.4)]
        public void GetResoult_ForGivenCommentSpeedDistanceDistanceUnitAndCombustion_ReturnsGivenTravelResoult(double speed, double distance, DistanceUnits distanceUnit,
            double combustion)
        {
            string comment = "Any comment";

            var commentDeterminator = new Mock<ITimeCommentDeterminator>();

            commentDeterminator.Setup(m => m.DererminateCommentForTime(It.IsAny<Time>()))
                .Returns(comment);

            TravelCalculatorFacade calculatorFacade = new TravelCalculatorFacade(CounterTypes.KilometersPerHour, commentDeterminator.Object);

            var resoultTravel = calculatorFacade.GetResoult(speed, distance, distanceUnit, combustion);

            resoultTravel.TravelTime.Hours.Should().BeGreaterThanOrEqualTo(0);

            resoultTravel.TravelTime.Minutes.Should().BeGreaterThanOrEqualTo(0);
            resoultTravel.TravelTime.Minutes.Should().BeLessThanOrEqualTo(60);

            resoultTravel.FuelConsumption.Should().NotBeNull();

            resoultTravel.Comment.Should().Be(comment);
        }
    }
}

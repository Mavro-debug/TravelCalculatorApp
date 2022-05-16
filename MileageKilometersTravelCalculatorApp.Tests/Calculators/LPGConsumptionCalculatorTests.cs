using Xunit;
using MileageKilometersTravelCalculatorApp.Service.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using FluentAssertions;

namespace MileageKilometersTravelCalculatorApp.Service.Calculators.Tests
{
    public class LPGConsumptionCalculatorTests
    {

        [Theory()]
        [InlineData(10, 100, CounterTypes.KilometersPerHour, DistanceUnits.Kilometers, 12.424242424242424242424242424242)]
        [InlineData(20, 100, CounterTypes.KilometersPerHour, DistanceUnits.Kilometers, 24.848484848484848484848484848484)]
        [InlineData(10, 100, CounterTypes.KilometersPerHour, DistanceUnits.Miles, 19.994918364649764620796373214417)]
        [InlineData(20, 100, CounterTypes.KilometersPerHour, DistanceUnits.Miles, 39.989836729299529241592746428834)]
        [InlineData(10, 100, CounterTypes.MilesPerHour, DistanceUnits.Kilometers, 7.720051515151516)]
        [InlineData(20, 100, CounterTypes.MilesPerHour, DistanceUnits.Kilometers, 15.440103030303032)]
        [InlineData(10, 100, CounterTypes.MilesPerHour, DistanceUnits.Miles, 12.424242424242424242424242424242)]
        [InlineData(20, 100, CounterTypes.MilesPerHour, DistanceUnits.Miles, 24.848484848484848484848484848484)]
        public void GetFuelConsumption_ForGivenCombustionDistanceCounterTypeAndDistanceUnitProvidesGivenResoult(double combustion, double distance,
            CounterTypes counterType, DistanceUnits distanceUnit,
            double predictedResolt)
        {
            var consumptionCalculator = new LPGConsumptionCalculator(counterType, distanceUnit);


            var resoult = consumptionCalculator.GetFuelConsumption(combustion, distance);


            resoult.Should().BeGreaterThanOrEqualTo(0);
            resoult.Should().Be(predictedResolt); ;
        }
    }
}
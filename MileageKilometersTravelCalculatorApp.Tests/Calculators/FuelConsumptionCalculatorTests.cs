using Xunit;
using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using FluentAssertions;

namespace MileageKilometersTravelCalculatorApp.Service.Calculators.Tests
{
    public class FuelConsumptionCalculatorTests
    {
        [Theory()]
        [InlineData(10, 100, CounterTypes.KilometersPerHour, DistanceUnits.Kilometers, 10)]
        [InlineData(20, 100, CounterTypes.KilometersPerHour, DistanceUnits.Kilometers, 20)]
        [InlineData(10, 100, CounterTypes.KilometersPerHour, DistanceUnits.Miles, 16.093470878864444694787324782336)]
        [InlineData(20, 100, CounterTypes.KilometersPerHour, DistanceUnits.Miles, 32.186941757728889389574649564672)]
        [InlineData(10, 100, CounterTypes.MilesPerHour, DistanceUnits.Kilometers, 6.2137)]
        [InlineData(20, 100, CounterTypes.MilesPerHour, DistanceUnits.Kilometers, 12.4274)]
        [InlineData(10, 100, CounterTypes.MilesPerHour, DistanceUnits.Miles, 10)]
        [InlineData(20, 100, CounterTypes.MilesPerHour, DistanceUnits.Miles, 20)]
        public void GetFuelConsumption_ForGivenCombustionDistanceCounterTypeAndDistanceUnitProvidesGivenResoult(double combustion, double distance,
            CounterTypes counterType, DistanceUnits distanceUnit,
            double predictedResolt)
        {
            var consumptionCalculator = new FuelConsumptionCalculator(counterType, distanceUnit);


            var resoult = consumptionCalculator.GetFuelConsumption(combustion, distance);


            resoult.Should().BeGreaterThanOrEqualTo(0);
            resoult.Should().Be(predictedResolt);
        }
    }
}
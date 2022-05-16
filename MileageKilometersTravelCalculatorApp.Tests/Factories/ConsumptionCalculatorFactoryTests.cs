using Xunit;
using MileageKilometersTravelCalculatorApp.Service.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Calculators;
using FluentAssertions;
using MileageKilometersTravelCalculatorApp.Service.Calculators;

namespace MileageKilometersTravelCalculatorApp.Service.Factories.Tests
{
    public class ConsumptionCalculatorFactoryTests
    {


        [Theory()]
        [InlineData(FuelType.Fuel, typeof(FuelConsumptionCalculator))]
        [InlineData(FuelType.LPG, typeof(LPGConsumptionCalculator))]
        public void GetConsumptionCalculator_WhenProvidedGivenFuelType_RetuensGivenClassType(FuelType fuelType, Type consumptionCalculatorType)
        {
            //arrange

            ConsumptionCalculatorFactory calculatorFactory = new ConsumptionCalculatorFactory();

            //act

            var calculatorResoult = calculatorFactory.GetConsumptionCalculator(fuelType, CounterTypes.KilometersPerHour, DistanceUnits.Kilometers);

            //assert

            calculatorResoult.Should().BeOfType(consumptionCalculatorType);
        }
    }
}
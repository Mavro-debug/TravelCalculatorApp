using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Calculators;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using MileageKilometersTravelCalculatorApp.Service.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileageKilometersTravelCalculatorApp.Service.Factories
{
    public class ConsumptionCalculatorFactory
    {
        public IConsumptionCalculator GetConsumptionCalculator(FuelType fuelType, CounterTypes counterType, DistanceUnits distanceUnit)
            => fuelType switch
            {
                FuelType.Fuel => new FuelConsumptionCalculator(counterType, distanceUnit),
                FuelType.LPG => new LPGConsumptionCalculator(counterType, distanceUnit),
                _ => throw new Exception("The factory was not able to provie consumption calculator")
            };
    }
}

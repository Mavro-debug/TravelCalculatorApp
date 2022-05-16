using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Calculators;
using MileageKilometersTravelCalculatorApp.Domein.Models;

namespace MileageKilometersTravelCalculatorApp.Service.Calculators
{
    public class FuelConsumptionCalculator : IConsumptionCalculator
    {
        private const double MKConst = 0.62137;
        private readonly CounterTypes _counterType;
        private readonly DistanceUnits _distanceUnit;

        public FuelConsumptionCalculator(CounterTypes counterType, DistanceUnits distanceUnit)
        {
            _counterType = counterType;
            _distanceUnit = distanceUnit;
        }

        public double GetFuelConsumption(double combustion, double distance)
        {
            double distanceAdjusted = AdjustDistanceToCounter(distance);

            return (combustion * distanceAdjusted) / 100;
        }

        private double AdjustDistanceToCounter(double distance)
        {
            if (_distanceUnit == DistanceUnits.Miles && _counterType == CounterTypes.KilometersPerHour)
            {
                return distance / MKConst;
            }
            else if (_distanceUnit == DistanceUnits.Kilometers && _counterType == CounterTypes.MilesPerHour)
            {
                return distance * MKConst;
            }

            return distance;
        }
    }
}

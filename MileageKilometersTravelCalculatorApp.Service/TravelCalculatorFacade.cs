using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using MileageKilometersTravelCalculatorApp.Service.Calculators;
using MileageKilometersTravelCalculatorApp.Service.Factories;
using MileageKilometersTravelCalculatorApp.Service.Helpers;
using MileageKilometersTravelCalculatorApp.Service.Strategies;
using MileageKilometersTravelCalculatorApp.Service.Strategy;

namespace MileageKilometersTravelCalculatorApp.Service
{
    public class TravelCalculatorFacade : ITravelCalculatorFacade
    {
        private readonly CounterTypes _counterType;
        private readonly ITimeCommentDeterminator _timeComment;

        public TravelCalculatorFacade(CounterTypes counterType, ITimeCommentDeterminator timeComment)
        {
            _counterType = counterType;
            _timeComment = timeComment;
        }


        private TravelTimeCalculator GetTimeCalculator(DistanceUnits distanceUnit)
        {
            if (MeasurementUnitsHelper.UnitsUnified(distanceUnit, _counterType))
            {
                return new TravelTimeCalculator(new UnifiedUnitsStrategy());
            }
            else
            {
                return new TravelTimeCalculator(new CrossUnitsStrategy(distanceUnit));
            }
        }

        public TravelResoult GetResoult(double speed, double distance, DistanceUnits distanceUnit, double? combustion, bool LPGCombustion = false)
        {
            TravelResoult resoult = new TravelResoult();

            var travelTimeCalculator = GetTimeCalculator(distanceUnit);


            resoult.TravelTime = travelTimeCalculator.CalculateTravelTime(speed, distance);
            resoult.Comment = _timeComment.DererminateCommentForTime(resoult.TravelTime);
            if (combustion != null)
            {
                resoult.FuelConsumption = new FuelConsumption();

                var consumptionCalculatorFactory = new ConsumptionCalculatorFactory();

                var fuelConsumptionCalculator = consumptionCalculatorFactory.GetConsumptionCalculator(FuelType.Fuel, _counterType, distanceUnit);

                resoult.FuelConsumption.Fuel = fuelConsumptionCalculator.GetFuelConsumption((double)combustion, distance);

                if (LPGCombustion)
                {
                    var LPGConsumptionCalculator = consumptionCalculatorFactory.GetConsumptionCalculator(FuelType.LPG, _counterType, distanceUnit);

                    resoult.FuelConsumption.LPG = LPGConsumptionCalculator.GetFuelConsumption((double)combustion, distance);
                }
            }

                

            return resoult;
        }

        
    }
}

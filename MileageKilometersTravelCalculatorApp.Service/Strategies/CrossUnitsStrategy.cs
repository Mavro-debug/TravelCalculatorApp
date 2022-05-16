using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Strategies;
using MileageKilometersTravelCalculatorApp.Domein.Models;

namespace MileageKilometersTravelCalculatorApp.Service.Strategy
{

    public class CrossUnitsStrategy : ITravelTimeCalculatorStrategy
    {
        private const double MKConst = 0.62137;
        private readonly DistanceUnits _distanceUnit;

        public CrossUnitsStrategy(DistanceUnits distanceUnit)
        {
            _distanceUnit = distanceUnit;
        }

        public Time GetTime(double speed, double distance)
           => _distanceUnit switch
           {
               DistanceUnits.Miles => CalculateTimeForMiles(speed, distance),
               DistanceUnits.Kilometers => CalculateTimeForKilometers(speed, distance),
               _ => throw new Exception()
           };

        private Time CalculateTimeForMiles(double speed, double distance)
        {
            double kilomiters = distance / MKConst;
            double hoursTotal = kilomiters / speed;
            double minutesTotal = hoursTotal * 60;

            Time time = new Time()
            {
                Hours = (int)hoursTotal,
                Minutes = (int)(minutesTotal % 60)
            };
            return time;
        }

        private Time CalculateTimeForKilometers(double speed, double distance)
        {
            double kilomiters = distance * MKConst;
            double hoursTotal = kilomiters / speed;
            double minutesTotal = hoursTotal * 60;

            Time time = new Time()
            {
                Hours = (int)hoursTotal,
                Minutes = (int)(minutesTotal % 60)
            };
            return time;
        }
    }
}

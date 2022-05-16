using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Strategies;
using MileageKilometersTravelCalculatorApp.Domein.Models;


namespace MileageKilometersTravelCalculatorApp.Service.Strategies
{
    public class UnifiedUnitsStrategy : ITravelTimeCalculatorStrategy
    {
        public Time GetTime(double speed, double distance)
        {
            double kilomiters = distance;
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

using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileageKilometersTravelCalculatorApp.Service.Helpers
{
    public static class MeasurementUnitsHelper
    {
        public static bool UnitsUnified(DistanceUnits distanceUnit, CounterTypes counterType)
        {
            if (distanceUnit == DistanceUnits.Miles && counterType == CounterTypes.KilometersPerHour)
            {
                return false;
            }
            
            if (distanceUnit == DistanceUnits.Kilometers && counterType == CounterTypes.MilesPerHour)
            {
                return false;
            }

            return true;
        }
    }
}

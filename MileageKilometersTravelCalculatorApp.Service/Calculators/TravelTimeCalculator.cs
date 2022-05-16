using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Strategies;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileageKilometersTravelCalculatorApp.Service.Calculators
{
    public class TravelTimeCalculator
    {
        private readonly ITravelTimeCalculatorStrategy _calculatorStrategy;

        public TravelTimeCalculator(ITravelTimeCalculatorStrategy calculatorStrategy)
        {
            _calculatorStrategy = calculatorStrategy;
        }

        public Time CalculateTravelTime(double speed, double distance)
        {
            return _calculatorStrategy.GetTime(speed, distance);
        }
    }
}

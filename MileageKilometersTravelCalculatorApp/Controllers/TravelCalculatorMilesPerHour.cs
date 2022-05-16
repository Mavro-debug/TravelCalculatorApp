using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces.Calculators;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using MileageKilometersTravelCalculatorApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileageKilometersTravelCalculatorApp.Controllers
{
    [Route("travelCalculatorMilesPerHour")]
    public class TravelCalculatorMilesPerHour : ControllerBase
    {
        private readonly ITravelCalculatorFacade _travelCalculatorFacade;
        private readonly IMapper _mapper;

        public TravelCalculatorMilesPerHour(ITimeCommentDeterminator timeComment, IMapper mapper)
        {
            this._travelCalculatorFacade = new TravelCalculatorFacade(CounterTypes.MilesPerHour, timeComment);
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("getSummaryWithMiles")]
        public IActionResult GetSummaryWithMiles([FromQuery] double speed, [FromQuery] double distance, [FromQuery] double? combustion = null, [FromQuery] bool LPGCombustion = false)
        {
            var travelResoult = _travelCalculatorFacade.GetResoult(speed, distance, DistanceUnits.Miles, combustion, LPGCombustion);
            var travelResoultDto = _mapper.Map<TravelResoultDto>(travelResoult);
            return Ok(travelResoultDto);
        }

        [HttpGet]
        [Route("getSummaryWithKilometers")]
        public IActionResult GetSummaryWithKilometers([FromQuery] double speed, [FromQuery] double distance, [FromQuery] double? combustion = null, [FromQuery] bool LPGCombustion = false)
        {
            var travelResoult = _travelCalculatorFacade.GetResoult(speed, distance, DistanceUnits.Kilometers, combustion, LPGCombustion);
            var travelResoultDto = _mapper.Map<TravelResoultDto>(travelResoult);
            return Ok(travelResoultDto);
        }
    }
}

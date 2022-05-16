using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MileageKilometersTravelCalculatorApp.Domein;
using MileageKilometersTravelCalculatorApp.Domein.Interfaces;
using MileageKilometersTravelCalculatorApp.Domein.Models;
using MileageKilometersTravelCalculatorApp.Service;


namespace MileageKilometersTravelCalculatorApp.Controllers
{
    [Route("travelCalculatorKilomitersPerHour")]
    public class TravelCalculatorKilomitersPerHour : ControllerBase
    {
        private readonly ITravelCalculatorFacade _travelCalculatorFacade;
        private readonly IMapper _mapper;

        public TravelCalculatorKilomitersPerHour(ITimeCommentDeterminator timeComment, IMapper mapper)
        {
            this._travelCalculatorFacade = new TravelCalculatorFacade(CounterTypes.KilometersPerHour, timeComment);
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

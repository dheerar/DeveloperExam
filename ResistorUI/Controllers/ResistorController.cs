using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resistor;
using Resistor.Models;
using System;

namespace ResistorUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResistorController : ControllerBase
    {
        private ICalculateOhmValues _calculateOhmValues;
        private readonly ILogger<ResistorController> _logger;

        public ResistorController(ICalculateOhmValues calculateOhmValues, ILogger<ResistorController> logger)
        {
            _calculateOhmValues = calculateOhmValues;
            _logger = logger;
        }

        [HttpGet]
        [Route("{bandAColor}/{bandBColor}/{bandCColor}/{bandDColor}")]
        public OhmResistance CalculateOhmValues(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            OhmResistance resistance = new OhmResistance();
            try
            {
                resistance = _calculateOhmValues.CalculateOhmResistanceValues(bandAColor, bandBColor, bandCColor, bandDColor);
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal Server Error. " + ex.Message);
            }
            return resistance;
        }
    }
}

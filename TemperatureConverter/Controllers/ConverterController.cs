using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureConverter.Services;

namespace TemperatureConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterController : ControllerBase
    {
        private readonly ILogger<ConverterController> _logger;
        private readonly IConverterService _converterService;

        public ConverterController(
            ILogger<ConverterController> logger,
            IConverterService converterService)
        {
            _logger = logger;
            _converterService = converterService;
        }

        [HttpGet]
        public IEnumerable<TemperatureResult> Get(string unit, double value)
        {
            return _converterService.Convert(unit, value);
        }
    }
}

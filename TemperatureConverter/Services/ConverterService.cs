using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureConverter.Services
{
    public class ConverterService : IConverterService
    {
        private readonly ILogger<ConverterService> _logger;

        public ConverterService(ILogger<ConverterService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<TemperatureResult> Convert(string unit, double value)
        {
            _logger.LogInformation("Converting value " + value + " " + unit);
            var response = new List<TemperatureResult>();

            if (unit != "kelvin")
            {
                switch (unit)
                {
                    case "celsius":
                        response.Add(new TemperatureResult
                        {
                            Unit = "kelvin",
                            Temperature = value + 273.15
                        });
                        break;
                    case "fahrenheit":
                        response.Add(new TemperatureResult
                        {
                            Unit = "kelvin",
                            Temperature = ((value - 32) * 5 / 9) + 273.15
                        });
                        break;
                    default:
                        break;
                }
            }

            if (unit != "celsius")
            {
                switch (unit)
                {
                    case "kelvin":
                        response.Add(new TemperatureResult
                        {
                            Unit = "celsius",
                            Temperature = value - 273.15
                        });
                        break;
                    case "fahrenheit":
                        response.Add(new TemperatureResult
                        {
                            Unit = "celsius",
                            Temperature = (value - 32) * 5 / 9
                        });
                        break;
                    default:
                        break;
                }
            }

            if (unit != "fahrenheit")
            {
                switch (unit)
                {
                    case "kelvin":
                        response.Add(new TemperatureResult
                        {
                            Unit = "fahrenheit",
                            Temperature = (value - 273.15) * 9 / 5 + 32
                        });
                        break;
                    case "celsius":
                        response.Add(new TemperatureResult
                        {
                            Unit = "fahrenheit",
                            Temperature = (value * 9 / 5) + 32
                        });
                        break;
                    default:
                        break;
                }
            }

            _logger.LogInformation("Successfully converted " + value + " " + unit);
            return response;
        }

    }
}

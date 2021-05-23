using System.Collections.Generic;

namespace TemperatureConverter.Services
{
    public interface IConverterService
    {
        IEnumerable<TemperatureResult> Convert(string unit, int value);

    }
}

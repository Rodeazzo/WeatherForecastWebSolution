using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class AccuWeatherWeatherModel
    {
        public CurrentTemperature Temperature { get; set; }
    }

    class CurrentTemperature
    {
        public MetricUnit Metric { get; set; }
    }

    class MetricUnit
    {
        public float Value { get; set; }
    }
}

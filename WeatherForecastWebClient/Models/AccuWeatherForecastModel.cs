using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class AccuWeatherForecastModel
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    class DailyForecast
    {
        public long EpochDate { get; set; }
        public ForecastTemperature Temperature { get; set; }
    }

    class ForecastTemperature
    {
        public Metric Minimum { get; set; }
        public Metric Maximum { get; set; }
    }

    class Metric
    {
        public float Value { get; set; }
    }
}

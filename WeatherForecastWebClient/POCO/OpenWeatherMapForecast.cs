using System;

namespace WeatherForecastWebClient.POCO
{
    class OpenWeatherMapForecast
    {
        public DateTime dateTime { get; }
        public float temperature { get; }

        public OpenWeatherMapForecast(DateTime dateTime, float temperature)
        {
            this.dateTime = dateTime;
            this.temperature = temperature;
        }
    }
}

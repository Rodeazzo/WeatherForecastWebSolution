﻿
namespace WeatherForecastWebClient.Models
{
    class OpenWeatherMapWeatherModel
    {
        public Main main { get; set; }
    }
    
    class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
    }
}

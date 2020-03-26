using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class Weather2020Controller : Controller
    {
        private Weather2020Endpoint weather2020Endpoint;

        public Weather2020Controller() : base ()
        {
            weather2020Endpoint = new Weather2020Endpoint();
        }

        public List<Weather2020Forecast> getForecast(string position)
        {
            List<Weather2020Forecast> forecastList = new List<Weather2020Forecast>();

            restClient.endpoint = weather2020Endpoint.getWeatherForecast(position);
            string response = restClient.makeRequest();

            JSONParser<List<Weather2020Model>> jsonParser = new JSONParser<List<Weather2020Model>>();

            List<Weather2020Model> deserialisedWeather2020Model = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            foreach (Weather2020Model weather2020 in deserialisedWeather2020Model)
            {
                forecastList.Add(new Weather2020Forecast(weather2020.startDate, 
                   weather2020.temperatureLow, 
                   weather2020.temperatureHigh));
            }

            return forecastList;
        }
    }
}

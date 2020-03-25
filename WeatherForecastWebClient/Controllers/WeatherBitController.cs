using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class WeatherBitController : Controller
    {
        private WeatherBitEndpoint weatherBitEndpoint;

        public WeatherBitController() : base()
        {
            weatherBitEndpoint = new WeatherBitEndpoint();
        }

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;

            restClient.endpoint = weatherBitEndpoint.getCurrentWeatherByCityNameEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<WeatherBitWeatherModel> jsonParser = new JSONParser<WeatherBitWeatherModel>();

            WeatherBitWeatherModel deserialisedWeatherBitWeatherModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            temperature = deserialisedWeatherBitWeatherModel.data[0].temp;
             
            return temperature;
        }

        public List<WeatherBitForecast> getWeatherForecast(string cityName)
        {
            List<WeatherBitForecast> forecastList = new List<WeatherBitForecast>();

            restClient.endpoint = weatherBitEndpoint.getWeatherForecast(cityName);
            string response = restClient.makeRequest();

            JSONParser<WeatherBitForecastModel> jsonParser = new JSONParser<WeatherBitForecastModel>();

            WeatherBitForecastModel deserialisedWeatherBitWeatherModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            foreach(Dataf data in deserialisedWeatherBitWeatherModel.data)
            {
                forecastList.Add(new WeatherBitForecast(data.datetime, data.min_temp, data.max_temp));
            }

            return forecastList;
        }
    }
}

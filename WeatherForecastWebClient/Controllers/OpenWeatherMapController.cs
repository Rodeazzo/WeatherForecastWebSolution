using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class OpenWeatherMapController : Controller
    {
        private OpenWeatherMapEndpoint openWeatherMapEndpoint;

        public OpenWeatherMapController() : base ()
        {
            this.openWeatherMapEndpoint = new OpenWeatherMapEndpoint();
        }

        public float getCurrentTemperature(string city, EndpointTypes endpointTypes)
        {
            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint(city, endpointTypes);
            string response = restClient.makeRequest();

            JSONParser<OpenWeatherMapWeatherModel> jsonParser = new JSONParser<OpenWeatherMapWeatherModel>();
            OpenWeatherMapWeatherModel deserializedOpenWeatherMapModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            float temperature = deserializedOpenWeatherMapModel.main.temp;
            return temperature;
        }

        public List<OpenWeatherMapForecast> getForecastList(string city, EndpointTypes endpointTypes) 
        {
            List<OpenWeatherMapForecast> forecastList = new List<OpenWeatherMapForecast>();

            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint(city, endpointTypes);
            string response = restClient.makeRequest();

            JSONParser<OpenWeatherMapForecastModel> jsonParser = new JSONParser<OpenWeatherMapForecastModel>();
            OpenWeatherMapForecastModel deserializedOpenWeatherMapForecastModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            foreach (ForecastModel.UnnamedObject forecastMain in deserializedOpenWeatherMapForecastModel.list)
            {
                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(forecastMain.dt).UtcDateTime;
                forecastList.Add(new OpenWeatherMapForecast(dateTime, forecastMain.main.temp));
            }

            return forecastList;
        }
    }
}

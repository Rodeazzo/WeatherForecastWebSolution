using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class ClimaCellController : Controller
    {
        private ClimaCellEndpoint climaCellEndpoint;

        public ClimaCellController() : base()
        {
            climaCellEndpoint = new ClimaCellEndpoint();
        }

        public float getCurrentWeather(string latitude, string longitude, EndpointTypes endpointTypes)
        {
            restClient.endpoint = climaCellEndpoint.getCurrentWeather(latitude, longitude, endpointTypes);
            string response = restClient.makeRequest();

            JSONParser<ClimaCellWeatherModel> jsonParser = new JSONParser<ClimaCellWeatherModel>();

            ClimaCellWeatherModel deserialisedClimaCellWeatherModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            float value = deserialisedClimaCellWeatherModel.temp.value;
            return value;
        }

        public List<ClimaCellForecast> getForecast(string latitude, string longitude, EndpointTypes endpointTypes)
        {
            List<ClimaCellForecast> forecastList = new List<ClimaCellForecast>();

            restClient.endpoint = climaCellEndpoint.getForecast(latitude, longitude, endpointTypes);
            string response = restClient.makeRequest();

            JSONParser<ClimaCellForecastModel> jsonParser = new JSONParser<ClimaCellForecastModel>();

            ClimaCellForecastModel deserialisedClimaCellForecastModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            foreach (Forecast climaCell in deserialisedClimaCellForecastModel.temp)
            {
                forecastList.Add(new ClimaCellForecast(climaCell.observation_time, climaCell.min.value,
                   climaCell.min.units));
                //forecastList.Add(new ClimaCellForecast(climaCell.observation_time, climaCell.max.value, climaCell.max.units));
            }

            return forecastList;
        }
    }
}

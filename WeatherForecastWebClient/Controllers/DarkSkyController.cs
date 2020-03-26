using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class DarkSkyController : Controller
    {
        private DarkSkyEndpoint darkSkyEndpoint;

        public DarkSkyController() : base()
        {
            darkSkyEndpoint = new DarkSkyEndpoint();
        }

        public List<DarkSkyForecast> getForecast(string position)
        {
            List<DarkSkyForecast> forecastList = new List<DarkSkyForecast>();

            restClient.endpoint = darkSkyEndpoint.getForecast(position);
            string response = restClient.makeRequest();

            JSONParser<DarkSkyForecastModel> jsonParser = new JSONParser<DarkSkyForecastModel>();

            DarkSkyForecastModel deserialisedDarkSkyForecastModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            foreach (DarkSkyData dailyForecast in deserialisedDarkSkyForecastModel.daily.data)
            {
                forecastList.Add(new DarkSkyForecast(deserialisedDarkSkyForecastModel.timezone,
                 dailyForecast.time,
                 dailyForecast.temperatureMin,
                 dailyForecast.temperatureMax));
            }

            return forecastList;
        }
    }
}

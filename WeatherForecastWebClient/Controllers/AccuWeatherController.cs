using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class AccuWeatherController : Controller
    {
        private AccuWeatherEndpoint accuWeatherEndpoint;

        public AccuWeatherController() : base()
        {
            accuWeatherEndpoint = new AccuWeatherEndpoint();
        }

        public string getLocationKey(string cityName)
        {
            restClient.endpoint = accuWeatherEndpoint.getLocationsEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<List<AccuWeatherLocationsModel>> jsonParser = new JSONParser<List<AccuWeatherLocationsModel>>();

            List<AccuWeatherLocationsModel> deserialisedAccuWeatherModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            string locationKey = deserialisedAccuWeatherModel[0].Key;
            return locationKey;
        }

        public string getLocationGeoPosition(string cityName)
        {
            restClient.endpoint = accuWeatherEndpoint.getLocationsEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<List<AccuWeatherLocationsModel>> jsonParser = new JSONParser<List<AccuWeatherLocationsModel>>();

            List<AccuWeatherLocationsModel> deserialisedAccuWeatherModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            float latitude = deserialisedAccuWeatherModel[0].GeoPosition.Latitude;
            float longitude = deserialisedAccuWeatherModel[0].GeoPosition.Longitude;

            string geoPosition = latitude + "," + longitude;

            return geoPosition;
        }

        public float getCurrentWeather(string cityName)
        {
            restClient.endpoint = accuWeatherEndpoint.getCurrentConditionsEndpoint(getLocationKey(cityName));
            string response = restClient.makeRequest();

            JSONParser<List<AccuWeatherWeatherModel>> jsonParser = new JSONParser<List<AccuWeatherWeatherModel>>();

            List<AccuWeatherWeatherModel> deserialisedAccuWeatherModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            float temperature = deserialisedAccuWeatherModel[0].Temperature.Metric.Value;
            return temperature;
        }

        public List<AccuWeatherForecast> getForecast(string cityName)
        {
            List<AccuWeatherForecast> forecastList = new List<AccuWeatherForecast>();

            restClient.endpoint = accuWeatherEndpoint.getForecastEndpoint(getLocationKey(cityName));
            string response = restClient.makeRequest();

            JSONParser<AccuWeatherForecastModel> jsonParser = new JSONParser<AccuWeatherForecastModel>();

            AccuWeatherForecastModel deserialisedAccuWeatherModel = jsonParser.ParseJSON(response, Parser.Version.NETCore3);

            foreach (DailyForecast dailyForecast in deserialisedAccuWeatherModel.DailyForecasts)
            {
                forecastList.Add(new AccuWeatherForecast(dailyForecast.EpochDate, dailyForecast.Temperature.Minimum.Value, dailyForecast.Temperature.Maximum.Value));
            }

            return forecastList;
        }
    }
}

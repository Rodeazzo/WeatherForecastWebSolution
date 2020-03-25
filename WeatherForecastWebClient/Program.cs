using System;
using System.Text.Json;
using WeatherForecastWebClient.Controllers;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Output;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //OpenWeatherMap API
            //openWeatherMapCurrentAPI();
            //openWeatherMapForecastAPI();

            //AccuWeather API
            //accuWeatherCurrentConditionsAPI();
            //accuWeatherForecastAPI();

            //WeatherBit API
            //weatherBitCurrentAPI();
            weatherBitForecastAPI();

            Console.ReadKey();
        }

        static void openWeatherMapCurrentAPI()
        {
            Out output = new Out();

            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            output.outputToConsole("\n**** Open Weather Map Current Weather ****");

            string cityName = "Valletta";
            output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName, EndpointTypes.CURRENT)}");

            cityName = "London";
            output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName, EndpointTypes.CURRENT)}");
        }

        static void openWeatherMapForecastAPI()
        {
            Out output = new Out();

            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            output.outputToConsole("\n**** Open Weather Map Forecast ****");

            string cityName = "Valletta";

            output.outputToConsole($"Forecast weather for: {cityName}");

            foreach (OpenWeatherMapForecast forecast in openWeatherMapController.getForecastList(cityName, EndpointTypes.FORECAST))
            {
                output.outputToConsole($"Date/Time: {forecast.dateTime} Temperature: {forecast.temperature}");
            }
        }

        static void accuWeatherCurrentConditionsAPI()
        {
            Out output = new Out();

            AccuWeatherController accuWeatherController = new AccuWeatherController();

            output.outputToConsole("\n**** AccuWeather Current Conditions ****");

            string cityName = "Valletta";

            output.outputToConsole($"Location key for city {cityName} is {accuWeatherController.getCurrentWeather(cityName)}");
        }

        static void accuWeatherForecastAPI()
        {
            Out output = new Out();

            AccuWeatherController accuWeatherController = new AccuWeatherController();

            output.outputToConsole("\n**** AccuWeather Forecast ****");

            string cityName = "Valletta";

            foreach (AccuWeatherForecast forecast in accuWeatherController.getForecast(cityName))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }

        static void weatherBitCurrentAPI()
        {
            Out output = new Out();

            WeatherBitController weatherBitController = new WeatherBitController();

            output.outputToConsole("\n**** WeatherBit Current Weather ****");

            string cityName = "Valletta";

            output.outputToConsole($"Temperature for {cityName}: {weatherBitController.getCurrentWeather(cityName)}");
        }

        static void weatherBitForecastAPI()
        {
            Out output = new Out();

            WeatherBitController weatherBitController = new WeatherBitController();

            output.outputToConsole("\n**** WeatherBit Forecast ****");

            string cityName = "Valletta";

            foreach (WeatherBitForecast forecast in weatherBitController.getWeatherForecast(cityName))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinTemp()} Maximum: {forecast.getMaxTemp()}");
            }
        }
    }
}

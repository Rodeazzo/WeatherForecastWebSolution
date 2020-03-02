using System;
using System.Text.Json;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Output;
using WeatherForecastWebClient.Parser;

namespace WeatherForecastWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = String.Empty;

            RestClient restClient = new RestClient();
            OpenWeatherMapEndpoint openWeatherMapEndpoint = new OpenWeatherMapEndpoint();

            // Set Endpoint to Current Weather Endpoint
            openWeatherMapEndpoint.setCurrentWeatherEndpoint(EndpointTypes.CURRENTWEATHER);

            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint("Valletta");
            response = restClient.makeRequest();
            processOpenWeatherMapResponse(response);

            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint("London");
            response = restClient.makeRequest();
            processOpenWeatherMapResponse(response);

            // Set Endpoint to Forecast Endpoint
            openWeatherMapEndpoint.setCurrentWeatherEndpoint(EndpointTypes.FORECAST);

            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint("Valletta");
            response = restClient.makeRequest();
            processOpenWeatherMapForecastModel(response);

            //Console.ReadKey();
        }

        static void processOpenWeatherMapResponse(string response)
        {
            Out output = new Out();

            //OpenWeatherMapWeatherModel openWeatherMapWeatherModel = JsonSerializer.Deserialize<OpenWeatherMapWeatherModel>(response);
            JSONParser<OpenWeatherMapWeatherModel> jsonParser = new JSONParser<OpenWeatherMapWeatherModel>();
            OpenWeatherMapWeatherModel deserializedOpenWeatherMapModel = jsonParser.ParseJSON(response);

            output.outputToConsole($"Temperature: {deserializedOpenWeatherMapModel.main.temp}");

            output.outputToConsole(response);
        }

        static void processOpenWeatherMapForecastModel(string response)
        {
            Out output = new Out();

            //OpenWeatherMapForecastModel openWeatherMapForecastModel = JsonSerializer.Deserialize<OpenWeatherMapForecastModel>(response);
            JSONParser<OpenWeatherMapForecastModel> jsonParser = new JSONParser<OpenWeatherMapForecastModel>();
            OpenWeatherMapForecastModel deserializedOpenWeatherForecastModel = jsonParser.ParseJSON(response);

            output.outputToConsole("\n**** Open Weather Map Forecast ****");

            foreach(ForecastModel.ListEmptyObject forecastMain in deserializedOpenWeatherForecastModel.list)
            {
                DateTime dateTime = new DateTime(1970,1,1).AddSeconds(forecastMain.dt);
                output.outputToConsole($"Date/Time: {dateTime.ToString()} \nTemperature: {forecastMain.main.temp}");
            }

            //output.outputToConsole(response);
        }
    }
}

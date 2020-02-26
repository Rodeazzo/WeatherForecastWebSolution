using System;
using System.Text.Json;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Output;

namespace WeatherForecastWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = String.Empty;

            Out output = new Out();

            RestClient restClient = new RestClient();
            OpenWeatherMapEndpoint openWeatherMapEndpoint = new OpenWeatherMapEndpoint();
            
            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint("Valletta");
            response = restClient.makeRequest();
            OpenWeatherMapWeatherModel openWeatherMapWeatherModel = JsonSerializer.Deserialize<OpenWeatherMapWeatherModel>(response);

            output.outputToConsole($"Temperature: {openWeatherMapWeatherModel.main.temp}");

            output.debugOutput(response);

            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint("London");
            response = restClient.makeRequest();
            output.outputToConsole(response);

            Console.ReadKey();
        }
    }
}

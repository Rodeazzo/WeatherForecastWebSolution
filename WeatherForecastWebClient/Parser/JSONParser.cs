using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WeatherForecastWebClient.Parser
{
    class JSONParser<T>
    {
        public T ParseJSON(string json)
        {
            var deserializedModel = JsonSerializer.Deserialize<T>(json);
            return deserializedModel;
        }        
    }
}

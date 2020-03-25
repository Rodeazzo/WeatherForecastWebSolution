using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Controllers
{
    abstract class Controller
    {
        protected RestClient restClient;

        public Controller()
        {
            restClient = new RestClient();
        }
    }
}

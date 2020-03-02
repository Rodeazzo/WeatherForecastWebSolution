using System;

namespace WeatherForecastWebClient.Output
{
    class Out
    {
        public Out() { }

        public void outputToConsole(string output)
        {
            Console.WriteLine(output);
        }

        public void debugOutput(string debugOutput)
        {
            System.Diagnostics.Debug.WriteLine(debugOutput + Environment.NewLine);
        }
    }
}

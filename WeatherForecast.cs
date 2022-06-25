using System.Text.Json.Serialization;

namespace WeatherAppChallenge
{
    public class OpenWeatherResponse
    {
        public string Name { get; set; }
        public IEnumerable<WeatherDescription> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public string Humidity { get; set; }
    }

    public class Wind
    {
        public string speed { get; set; }
    }
}
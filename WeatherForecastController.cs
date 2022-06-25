using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WeatherAppChallenge.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
      
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]/{city}")]
        public async Task<OkObjectResult> WeatherForecast(string city)
        {
           using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"/data/2.5/weather?q={city}&units=metric&appid=8113fcc5a7494b0518bd91ef3acc074f");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var openWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(result);
                var res = new OpenWeatherResponse();
                return Ok(new
                {
                    temp = openWeather.Main.Temp,
                    minTemp = openWeather.Main.temp_min,
                    maxTemp = openWeather.Main.temp_max,
                    humidity = openWeather.Main.Humidity,
                    summary = string.Join(",", openWeather.Weather.Select(x => x.Main)),
                    city = openWeather.Name,
                    wind = openWeather.Wind.speed
                });
            }
        }
    }
}
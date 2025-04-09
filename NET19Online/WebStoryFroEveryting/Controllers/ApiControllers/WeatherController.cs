using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStoryFroEveryting.Models.Weather;
using WebStoryFroEveryting.Services.Apis;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class WeatherController : Controller
	{
		private HttpWeatherApi _httpWeatherApi;

		public WeatherController(HttpWeatherApi httpWeatherApi)
		{
			_httpWeatherApi = httpWeatherApi;
		}

		public async Task<WeatherViewModel> GetWeather(double latitude, double longitude)
		{
			var weatherDto = await _httpWeatherApi
				.GetWeatherAsync(latitude.ToString(), longitude.ToString());

			var temperatures = new List<List<string>>();
			for (int i = 0; i < 24; i++)
			{
				var hour = weatherDto
					.hourly
					.time[i]
					.Split('T')[1]
					.Split(':')[0];//  "2025-04-15T01:00",
				var temperature = weatherDto.hourly.temperature_2m[i];
				temperatures.Add(new List<string> { hour, temperature.ToString() });
			}
			
			var viewModel = new WeatherViewModel
			{
				CurrentTemperature = $"{weatherDto.current.temperature_2m} {weatherDto.current_units.temperature_2m}",
				UnitsOfMeasurement = weatherDto.current_units.temperature_2m,
				Temperatures = temperatures
			};
			return viewModel;
		}
	}
}

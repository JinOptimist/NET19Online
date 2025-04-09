
using WebStoryFroEveryting.Services.Apis.Dtos;

namespace WebStoryFroEveryting.Services.Apis
{
	public class HttpWeatherApi
	{
		private HttpClient _httpClient;

		public HttpWeatherApi(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<WeatherDto> GetWeatherAsync(string latitude = "53", string longitude = "27")
		{
			var response = await _httpClient.GetAsync($"?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m");
			var weatherDto = await response.Content.ReadFromJsonAsync<WeatherDto>();
			return weatherDto;
		}
	}
}

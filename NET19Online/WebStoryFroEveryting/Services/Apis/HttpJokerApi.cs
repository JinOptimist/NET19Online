namespace WebStoryFroEveryting.Services.Apis
{
	public class HttpJokerApi
	{
		private HttpClient _httpClient;

		public HttpJokerApi(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetJokeAsync()
		{
			var response = await _httpClient.GetAsync("random_joke");
			var joke = await response.Content.ReadFromJsonAsync<Joke>();
			return $"{joke.Setup} ..... {joke.Punchline}";
		}

		private class Joke
		{
			public string Setup { get; set; }
			public string Punchline { get; set; }
		}
	}
}

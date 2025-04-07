namespace WebStoryFroEveryting.Services.Apis
{
	public class HttpNumberApi
	{
		private HttpClient _httpClient;

		public HttpNumberApi(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetFactAboutNumberAsync(int number = 42)
		{
			var response = await _httpClient.GetAsync(number.ToString());
			return await response.Content.ReadAsStringAsync();
		}
	}
}

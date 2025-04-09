namespace WebStoryFroEveryting.Services.Apis.UnderwaterHunterApi
{
    public class HttpQuoteApi
    {
        private HttpClient _httpClient;

        public HttpQuoteApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetQuoteAsync()
        {
            var response = await _httpClient.GetAsync("");
            var qouter = await response
                .Content
                .ReadFromJsonAsync<Quoter>();
            var qouteWithAuthor = $"{qouter.Quote.Body} | Author: {qouter.Quote.Author}";
            
            return qouteWithAuthor;
        }
    }
}

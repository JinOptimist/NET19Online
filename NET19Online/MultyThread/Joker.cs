using System.Net.Http.Json;

namespace MultyThread
{
    public class Joker
    {
        public async Task<Joke> GetJokeAsync()
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            
            var response = await http.GetAsync("random_joke");

            var joke = await response
                .Content
                .ReadFromJsonAsync<Joke>();

            Console.WriteLine(joke.Setup);
            Console.WriteLine(joke.Punchline);
            return joke;
        }

        public class Joke
        {
            public string Setup { get; set; }
            public string Punchline { get; set; }
        }
    }
}

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class WordFetcher
    {
        private readonly HttpClient httpClient;

        public WordFetcher()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://random-word-api.herokuapp.com/")
            };
        }

        public async Task<string> FetchRandomWordAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("word?number=1");

                if (response.IsSuccessStatusCode)
                {
                    var words = await response.Content.ReadFromJsonAsync<string[]>();
                    return words != null && words.Length > 0 ? words[0].ToUpper() : "ERROR"; // Kontrollera null och längd
                }
                else
                {
                    return "ERROR"; // Om anropet misslyckas
                }
            }
            catch
            {
                return "ERROR"; // --||--
            }
        }
    }
}
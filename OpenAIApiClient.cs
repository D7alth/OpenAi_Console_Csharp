using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OpenAiConsole
{
    public class OpenAIApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAIApiClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        }
        public async Task<string> SendPrompt(string prompt, string model)
        {
            var requestBody = new
            {
                prompt = prompt,
                model = model, 
                max_tokens = 150,
                temperature = 0.5
            }; 

            var response = await _httpClient.PostAsJsonAsync("completions", requestBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}